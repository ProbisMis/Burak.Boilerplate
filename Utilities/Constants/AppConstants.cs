﻿using System.Globalization;

namespace Burak.Boilerplate.Utilities.Constants
{
    public class AppConstants
    {
        public const string SolutionName = "Burak.Boilerplate";
        public const string DataStorageSection = "DataStorageSection";
        public const string AcceptedLanguageHeaderKey = "Accept-Language";
        public static CultureInfo DefaultCultureInfo = new CultureInfo("en-US");
        public const string AppCenterTokenHeaderKey = "X-API-Token";
        public const string AppCenterNotificationSoundCustomDataKey = "sound";
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 25;
        public const string JWTSecretKey = "This is a secret key, it should not be shared with others!";


        /* Appointment Status */
        public const string AppointmentStatusPending = "Pending";
    }
}