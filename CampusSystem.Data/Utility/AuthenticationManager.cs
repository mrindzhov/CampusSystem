namespace CampusSystem.Data.Utility
{
    using Models;
    using System;

    /// <summary>
    /// Class used for simple authentication validation.
    /// NOTE: If class is declared as static all of its members, fields and methods MUST be static as well.
    /// </summary>
    public static class AuthenticationManager
    {
        private static Campus currentCampus;

        /// <summary>
        /// Checks if there is current logged in user.
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthenticated()
        {
            return currentCampus != null;
        }

        /// <summary>
        /// Logout current user.
        /// </summary>
        public static void Logout()
        {
            if (!IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            currentCampus = null;
        }

        /// <summary>
        /// Logs in the user specified.
        /// </summary>
        /// <param name="campus"></param>
        public static void Login(Campus campus)
        {
            if (IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout first!");
            }

            currentCampus = campus;
        }

        /// <summary>
        /// Gets currently logged in user.
        /// </summary>
        /// <returns></returns>

        public static Campus GetCurrentCampus()
        {
            return currentCampus;
        }
    }
}