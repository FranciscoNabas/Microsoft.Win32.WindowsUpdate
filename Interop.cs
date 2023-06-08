using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Win32.WindowsUpdate
{
    internal enum AutomaticUpdatesNotificationLevel
    {
        aunlNotConfigured,
        aunlDisabled,
        aunlNotifyBeforeDownload,
        aunlNotifyBeforeInstallation,
        aunlScheduledInstallation
    }

    internal enum AutomaticUpdatesScheduledInstallationDay
    {
        ausidEveryDay,
        ausidEverySunday,
        ausidEveryMonday,
        ausidEveryTuesday,
        ausidEveryWednesday,
        ausidEveryThursday,
        ausidEveryFriday,
        ausidEverySaturday
    }

    internal enum AutomaticUpdatesUserType
    {
        auutCurrentUser = 1,
        auutLocalAdministrator
    }

    internal enum AutomaticUpdatesPermissionType
    {
        auptSetNotificationLevel = 1,
        auptDisableAutomaticUpdates,
        auptSetIncludeRecommendedUpdates,
        auptSetFeaturedUpdatesEnabled,
        auptSetNonAdministratorsElevated
    }

    [ComImport]
    [Guid("673425BF-C082-4C7C-BDFD-569464B8E0CE")]
    internal interface IAutomaticUpdates
    {
        IAutomaticUpdatesSettings Settings { [return: MarshalAs(UnmanagedType.Interface)] get; }
        bool ServiceEnabled { get; }

        void DetectNow();
        void Pause();
        void Resume();
        void ShowSettingsDialog();
        void EnableService();
    }

    [ComImport]
    [Guid("4A2F5C31-CFD9-410E-B7FB-29A653973A0F")]
    internal interface IAutomaticUpdates2 : IAutomaticUpdates
    {
        IAutomaticUpdatesResult Results { [return: MarshalAs(UnmanagedType.Interface)] get; }
    }

    [ComImport]
    [Guid("E7A4D634-7942-4DD9-A111-82228BA33901")]
    internal interface IAutomaticUpdatesResult
    {
        object LastSearchSuccessDate { [return: MarshalAs(UnmanagedType.Struct)] get; }
    }

    [ComImport]
    [Guid("2EE48F22-AF3C-405F-8970-F71BE12EE9A2")]
    internal interface IAutomaticUpdatesSettings
    {
        AutomaticUpdatesNotificationLevel NotificationLevel { [return: MarshalAs(UnmanagedType.U4)] get; [param: MarshalAs(UnmanagedType.U4)] set; }
        bool ReadOnly { get; }
        bool Required { get; }
        AutomaticUpdatesScheduledInstallationDay ScheduledInstallationDay { [return: MarshalAs(UnmanagedType.U4)] get; [param: MarshalAs(UnmanagedType.U4)] set; }
        int ScheduledInstallationTime { get; set; }

        void Refresh();
        void Save();
    }

    [ComImport]
    [Guid("6ABC136A-C3CA-4384-8171-CB2B1E59B8DC")]
    internal interface IAutomaticUpdatesSettings2 : IAutomaticUpdatesSettings
    {
        bool IncludeRecommendedUpdates { get; set; }
        bool CheckPermission([In] AutomaticUpdatesUserType userType, [In] AutomaticUpdatesPermissionType permissionType);
    }

    [ComImport]
    [Guid("B587F5C3-F57E-485F-BBF5-0D181C5CD0DC")]
    internal interface IAutomaticUpdatesSettings3 : IAutomaticUpdates2
    {
        bool NonAdministratorsElevated { get; set; }
        bool FeaturedUpdatesEnabled { get; set; }
    }

    [ComImport]
    [Guid("81DDC1B8-9D35-47A6-B471-5B80F519223B")]
    internal interface ICategory
    {
        string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }
        string CategoryId { [return: MarshalAs(UnmanagedType.BStr)] get; }
        ICategoryColletion Children { [return: MarshalAs(UnmanagedType.Interface)] get; }
        string Description { [return: MarshalAs(UnmanagedType.BStr)] get; }
        IImageInformation Image { [return: MarshalAs(UnmanagedType.Interface)] get; }
        int Order { get; }
        ICategory Parent { [return: MarshalAs(UnmanagedType.Interface)] get; }
        string Type { [return: MarshalAs(UnmanagedType.BStr)] get; }
        UpdateCollection Updates { [return: MarshalAs(UnmanagedType.Interface)] get; }
    }

    [ComImport]
    [Guid("3A56BFB8-576C-43F7-9335-FE4838FD7E37")]
    internal interface ICategoryColletion : IEnumerable
    {
        ICategory this[[In] int index] { [return: MarshalAs(UnmanagedType.Interface)] get; }
        int Count { get; }
        new IEnumerator GetEnumerator();
    }

    [ComImport]
    [Guid("7C907864-346C-4AEB-8F3F-57DA289F969F")]
    internal interface IImageInformation
    {
        string AltText { [return: MarshalAs(UnmanagedType.BStr)] get; }
        string Height { [return: MarshalAs(UnmanagedType.BStr)] get; }
        string Source { [return: MarshalAs(UnmanagedType.BStr)] get; }
        string Width { [return: MarshalAs(UnmanagedType.BStr)] get; }
    }



    [ComImport]
    [Guid("07F7438C-7709-4CA5-B518-91279288134E")]
    internal interface IUpdateCollection
    {

    }

    [ComImport]
    [CoClass(typeof(UpdateCollectionClass))]
    [Guid("07F7438C-7709-4CA5-B518-91279288134E")]
    internal interface UpdateCollection : IUpdateCollection
    {
    }

    [ComImport]
    [Guid("13639463-00DB-4646-803D-528026140D88")]
    internal class UpdateCollectionClass : IUpdateCollection, UpdateCollection, IEnumerable
    {

    }
}