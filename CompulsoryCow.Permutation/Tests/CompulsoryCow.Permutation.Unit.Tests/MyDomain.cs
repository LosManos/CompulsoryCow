namespace CompulsoryCow.Permutation.Unit.Tests;

public class MyDomain
{
    public enum PageEnum{
        LandingPage, 
        AdminPage,
        ContentPage
    }

    public bool Authorise( PageEnum page, bool isLoggedOn, bool isAdmin)
    {
        switch(page){
            // Everyone can read the landing page.
            case PageEnum.LandingPage:
                return true;

            // Only admins can read the admin pages.
            case PageEnum.AdminPage:
                return isLoggedOn && isAdmin;

            // The user has to be logged on to read any content.
            case PageEnum.ContentPage:
                return isLoggedOn;

            // Don't know what happened, it seems we forgot to authorise a page; Bail.
            default:
                return false;
        }
    }
}
