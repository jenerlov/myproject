using myproject.Models;

namespace myproject.Services;

public class ShowcaseService
{
    private readonly List<ShowcaseModel> _showcases = new()
    {
        new ShowcaseModel()
        {
            Ingress = "Welcome",
            Title = "Blablabla",
            ImageUrl = "images/placeholders/625x647.svg",
            // Button = new LinkButtonModel
            // {
            //     Content = "Buy now",
            //     Url = "/products"
            // }
        },
                new ShowcaseModel()
        {
            Ingress = "Welcome",
            Title = "Blablabla",
            ImageUrl = "images/placeholders/625x647.svg",
            // Button = new LinkButtonModel
            // {
            //     Content = "Buy now",
            //     Url = "/products"
            // }
        },
    };

    public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!;
    }
}
