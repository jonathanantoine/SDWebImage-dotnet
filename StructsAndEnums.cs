using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SDWebImage {
    
    [Native]
    public enum SDImageCacheType : long
    {
        None = 0,
        Disk,
        Memory
    }
    
    [Flags]
    [Native]
    public enum SDWebImageOptions : ulong
    {
        RetryFailed = 1 << 0,
        LowPriority = 1 << 1,
        CacheMemoryOnly = 1 << 2,
        ProgressiveDownload = 1 << 3,
        RefreshCached = 1 << 4,
        ContinueInBackground = 1 << 5,
        HandleCookies = 1 << 6,
        AllowInvalidSSLCertificates = 1 << 7,
        HighPriority = 1 << 8,
        DelayPlaceholder = 1 << 9,
        TransformAnimatedImage = 1 << 10,
        AvoidAutoSetImage = 1 << 11,
        ScaleDownLargeImages = 1 << 12
    }
    
    [Flags]
    [Native]
    public enum SDWebImageDownloaderOptions : ulong /* nuint */ {
        SDWebImageDownloaderLowPriority = 1 << 0,
        SDWebImageDownloaderProgressiveDownload = 1 << 1,
        SDWebImageDownloaderUseNSURLCache = 1 << 2,
        SDWebImageDownloaderIgnoreCachedResponse = 1 << 3,
        SDWebImageDownloaderContinueInBackground = 1 << 4,
        SDWebImageDownloaderHandleCookies = 1 << 5,
        SDWebImageDownloaderAllowInvalidSSLCertificates = 1 << 6,
        SDWebImageDownloaderHighPriority = 1 << 7
    }
    
    [Native]
    public enum SDWebImageDownloaderExecutionOrder : long /* nint */ {
        SDWebImageDownloaderFIFOExecutionOrder,
        SDWebImageDownloaderLIFOExecutionOrder
    }
}
