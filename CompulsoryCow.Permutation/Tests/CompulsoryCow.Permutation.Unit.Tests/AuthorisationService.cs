namespace CompulsoryCow.Permutation.Unit.Tests;

public class AuthorisationService
{
    /// <summary>The pages of a web site
    /// where a user has to have certain credentials, or not
    /// to access/be authorised.
    /// </summary>
    public enum WebPage{
        LandingPage, 
        AdminPage,
        ContentPage
    }

    /// <summary>Fictive authorisation method
    /// returning true or false depending on if the user is authorised to a page or not.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="isLoggedOn"></param>
    /// <param name="isAdmin"></param>
    /// <returns></returns>
    public bool Authorise( WebPage page, bool isLoggedOn, bool isAdmin)
    {
        switch(page){
            // Everyone can read the landing page.
            case WebPage.LandingPage:
                return true;

            // Only admins can read the admin pages.
            case WebPage.AdminPage:
                return isLoggedOn && isAdmin;

            // The user has to be logged on to read any content.
            case WebPage.ContentPage:
                return isLoggedOn;

            // Don't know what happened, it seems we forgot to authorise a page; Bail.
            default:
                return false;
        }
    }
}
