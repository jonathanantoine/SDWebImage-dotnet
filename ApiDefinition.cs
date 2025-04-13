using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SDWebImage {
    
    
    // typedef void (^SDExternalCompletionBlock)(UIImage * _Nullable, NSError * _Nullable, SDImageCacheType, NSURL * _Nullable);
    delegate void SDExternalCompletionHandler ([NullAllowed] UIImage image, [NullAllowed] NSError error, SDImageCacheType cacheType, [NullAllowed] NSUrl imageUrl);

    
	[Category]
	[BaseType (typeof (UIImageView))]
	interface UIImageView_WebCache {
		// -(void)sd_setImageWithURL:(NSURL * _Nullable)url;
		[Export ("sd_setImageWithURL:")]
		void SetImage ([NullAllowed] NSUrl url);

		// -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder;
		[Export ("sd_setImageWithURL:placeholderImage:")]
		void SetImage ([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder);
        
        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export ("sd_setImageWithURL:placeholderImage:options:")]
        void SetImage ([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export ("sd_setImageWithURL:completed:")]
        void SetImage ([NullAllowed] NSUrl url, [NullAllowed] SDExternalCompletionHandler completedHandler);
        
        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export ("sd_setImageWithURL:placeholderImage:options:completed:")]
        void SetImage ([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionHandler completedHandler);
	}
    
    
    // @interface WebCache (UIView)
    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_WebCache
    {

        // -(void)sd_cancelCurrentImageLoad;
        [Export("sd_cancelCurrentImageLoad")]
        void CancelCurrentImageLoad();
    }
}
