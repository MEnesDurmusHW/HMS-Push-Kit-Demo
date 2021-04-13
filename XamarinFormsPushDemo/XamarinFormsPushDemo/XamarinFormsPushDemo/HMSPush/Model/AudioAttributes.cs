namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class AudioAttributes
    {
        public AudioContentType ContentType { get; set; }
        public AudioFlags Flags { get; set; }
        public AudioUsageKind Usage { get; set; }
        public Stream VolumeControlStream { get; set; }
    }

    public enum Stream
    {
        NotificationDefault = -1,
        VoiceCall = 0,
        System = 1,
        Ring = 2,
        Music = 3,
        Alarm = 4,
        Notification = 5,
        Dtmf = 8
    }

    public enum AudioUsageKind
    {
        Unknown = 0,
        Media = 1,
        VoiceCommunication = 2,
        VoiceCommunicationSignalling = 3,
        Alarm = 4,
        Notification = 5,
        NotificationRingtone = 6,
        NotificationCommunicationRequest = 7,
        NotificationCommunicationInstant = 8,
        NotificationCommunicationDelayed = 9,
        NotificationEvent = 10,
        AssistanceAccessibility = 11,
        AssistanceNavigationGuidance = 12,
        AssistanceSonification = 13,
        Game = 14,
        Assistant = 16
    }

    public enum AudioFlags
    {
        None = 0,
        AudibilityEnforced = 1,
        HwAvSync = 16,
        LowLatency = 256
    }

    public enum AudioContentType
    {
        Unknown = 0,
        Speech = 1,
        Music = 2,
        Movie = 3,
        Sonification = 4
    }
}