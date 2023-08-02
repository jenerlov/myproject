const express = require("express");
const csv = require("csv-parser");
const fs = require("fs");
const cors = require("cors");
const swaggerJsdoc = require("swagger-jsdoc");
const swaggerUi = require("swagger-ui-express");
const { createProxyMiddleware } = require("http-proxy-middleware");
const fetch = require("node-fetch");

const app = express();
app.use(cors());

const options = {
  definition: {
    openapi: "3.0.0",
    info: {
      title: "Pollen API Documentation",
      version: "1.0.0",
      description: "Pollen API documentation",
    },
    servers: [
      {
        url: "http://localhost:3002",
      },
    ],
  },
  apis: [__filename],
};

const specs = swaggerJsdoc(options);

app.use("/api-docs", swaggerUi.serve, swaggerUi.setup(specs));

// Proxy middleware
const apiProxy = createProxyMiddleware({
  target: "https://nominatim.openstreetmap.org",
  changeOrigin: true,
});

/**
 * @swagger
 * /pollen/cities:
 *   get:
 *     summary: Get the list of available cities.
 *     tags:
 *        - endpoints
 *     responses:
 *       200:
 *         description: Successful response
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 cities:
 *                   type: array
 *                   items:
 *                     type: string
 */
app.get("/pollen/cities", (req, res) => {
  const filePath = "/app/backend/files/Alnus_2017.csv";
  const cities = [];

  fs.createReadStream(filePath)
    .pipe(csv())
    .on("data", (data) => {
      const headers = Object.keys(data);
      const cityHeaders = headers.slice(1);

      cityHeaders.forEach((city) => {
        if (!cities.some((c) => c.name === city)) {
          cities.push({
            name: city,
            latitude: null,
            longitude: null,
          });
        }
      });
    })
    .on("end", () => {
      // Fetch coordinates for cities using Nominatim API
      const promises = cities.map((city) =>
        fetch(
          `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(
            city.name
          )}`
        )
      );

      Promise.all(promises)
        .then((responses) => Promise.all(responses.map((r) => r.json())))
        .then((results) => {
          results.forEach((result, index) => {
            if (result.length > 0) {
              cities[index].latitude = result[0].lat;
              cities[index].longitude = result[0].lon;
            }
          });
          res.json({ cities });
        })
        .catch((error) => {
          console.error("Error fetching coordinates for cities:", error);
          res.status(500).json({ error: "Internal server error" });
        });
    })
    .on("error", (error) => {
      console.error("Error reading CSV file:", error);
      res.status(500).json({ error: "Internal server error" });
    });
});

/**
 * @swagger
 * /pollen/types:
 *   get:
 *     summary: Get the list of available pollen types.
 *     tags:
 *        - endpoints
 *     responses:
 *       200:
 *         description: Successful response
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 pollenTypes:
 *                   type: array
 *                   items:
 *                     type: string
 */
app.get("/pollen/types", (req, res) => {
  const types = ["Alnus", "Betula", "Poaceae"];
  res.json({ types });
});

/**
 * @swagger
 * /pollen/years:
 *   get:
 *     summary: Get the list of available years.
 *     tags:
 *        - endpoints
 *     responses:
 *       200:
 *         description: Successful response
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 years:
 *                   type: array
 *                   items:
 *                     type: string
 */
app.get("/pollen/years", (req, res) => {
  const years = ["2017", "2018"];
  res.json({ years });
});

/**
 * @swagger
 * /pollen/{type}/{year}:
 *   get:
 *     summary: Get pollen data for a specific type and year.
 *     tags:
 *        - endpoints
 *     parameters:
 *       - in: path
 *         name: type
 *         required: true
 *         description: The type of pollen.
 *         schema:
 *           type: string
 *       - in: path
 *         name: year
 *         required: true
 *         description: The year of the pollen data.
 *         schema:
 *           type: string
 *     responses:
 *       200:
 *         description: Successful response
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 data:
 *                   type: array
 *                   items:
 *                     type: object
 *                     properties:
 *                       date:
 *                         type: string
 *                       pollenData:
 *                         type: array
 *                         items:
 *                           type: object
 *                           properties:
 *                             city:
 *                               type: string
 *                             level:
 *                               type: number
 */
app.get("/pollen/:type/:year", (req, res) => {
  const type = req.params.type;
  const year = req.params.year;
  // Validate the year input
  const validYears = ["2017", "2018"];
  const validTypes = ["Alnus", "Betula", "Poaceae"];
  if (!validYears.includes(year)) {
    return res.status(400).json({ error: "Invalid year" });
  }
  if (!validTypes.includes(type)) {
    return res.status(400).json({ error: "Invalid type of pollen" });
  }
  const filePath = `/app/backend/files/${type}_${year}.csv`;

  const pollenData = [];

  fs.createReadStream(filePath)
    .pipe(csv())
    .on("data", (data) => {
      const headers = Object.keys(data);
      const cityHeaders = headers.slice(1);
      const rowData = {
        date: data[headers[0]],
        pollenData: cityHeaders.map((city) => {
          return {
            city: city,
            level: parseFloat(data[city]),
          };
        }),
      };

      pollenData.push(rowData);
    })
    .on("end", () => {
      res.json({ data: pollenData });
    })
    .on("error", (error) => {
      console.error("Error reading CSV file:", error);
      res.status(500).json({ error: "Internal server error" });
    });
});

const port = 3002;
app.listen(port, () => {
  console.log(`Server listening on port ${port}`);
});

In this updated code, the `/pollen/cities` endpoint is now correctly reading the CSV file and extracting the unique city names. However, the code for fetching the latitude and longitude for each city is missing. To fetch the coordinates for each city, you can modify the code as follows:

```javascript
app.get("/pollen/cities", (req, res) => {
  const filePath = "/app/backend/files/Alnus_2017.csv";
  const cities = [];

  fs.createReadStream(filePath)
    .pipe(csv())
    .on("data", (data) => {
      const headers = Object.keys(data);
      const cityHeaders = headers.slice(1);

      cityHeaders.forEach((city) => {
        if (!cities.some((c) => c.name === city)) {
          cities.push({
            name: city,
            latitude: null,
            longitude: null,
          });
        }
      });
    })
    .on("end", () => {
      // Fetch coordinates for each city
      Promise.all(
        cities.map((city) =>
          fetch(
            `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(city.name)}`
          )
        )
      )
        .then((responses) => Promise.all(responses.map((response) => response.json())))
        .then((results) => {
          results.forEach((result, index) => {
            if (result.length > 0) {
              cities[index].latitude = result[0].lat;
              cities[index].longitude = result[0].lon;
            }
          });
          res.json({ cities });
        })
        .catch((error) => {
          console.error("Error fetching coordinates for cities:", error);
          res.status(500).json({ error: "Internal server error" });
        });
    })
    .on("error", (error) => {
      console.error("Error reading CSV file:", error);
      res.status(500).json({ error: "Internal server error" });
    });
});
