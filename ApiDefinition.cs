using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SDWebImage {
	[Category]
	[BaseType (typeof (UIImageView))]
	interface UIImageView_WebCache {
		// -(void)sd_setImageWithURL:(NSURL * _Nullable)url;
		[Export ("sd_setImageWithURL:")]
		void SetImage ([NullAllowed] NSUrl url);

		// -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder;
		[Export ("sd_setImageWithURL:placeholderImage:")]
		void SetImage ([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder);
	}
}
