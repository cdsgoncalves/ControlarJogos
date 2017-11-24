using System.Security.Claims;
using System.Security.Principal;

namespace Web.Extensions
{
    public static class ClaimsExtension
    {
        public static void AddUpdateClaim(this IPrincipal currentPrincipal, string key, string value)
        {
            if (!(currentPrincipal.Identity is ClaimsIdentity identity))
                return;

            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(key);

            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            identity.AddClaim(new Claim(key, value));
        }
    }
}