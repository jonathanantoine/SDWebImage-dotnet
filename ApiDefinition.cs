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
    
    
    // @protocol SDWebImageManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface SDWebImageManagerDelegate {
    
        // @optional -(BOOL)imageManager:(SDWebImageManager *)imageManager shouldDownloadImageForURL:(NSURL *)imageURL;
        [Export ("imageManager:shouldDownloadImageForURL:")]
        bool ShouldDownloadImageForURL (SDWebImageManager imageManager, NSUrl imageURL);
    
        // @optional -(UIImage *)imageManager:(SDWebImageManager *)imageManager transformDownloadedImage:(UIImage *)image withURL:(NSURL *)imageURL;
        [Export ("imageManager:transformDownloadedImage:withURL:")]
        UIImage TransformDownloadedImage (SDWebImageManager imageManager, UIImage image, NSUrl imageURL);
    }
    
    	// @interface SDWebImageDownloader : NSObject
	[BaseType (typeof (NSObject))]
	interface SDWebImageDownloader {
	
		// @property (assign, nonatomic) NSInteger maxConcurrentDownloads;
		[Export ("maxConcurrentDownloads", ArgumentSemantic.UnsafeUnretained)]
		nint MaxConcurrentDownloads { get; set; }
	
		// @property (readonly, nonatomic) NSUInteger currentDownloadCount;
		[Export ("currentDownloadCount")]
		nuint CurrentDownloadCount { get; }
	
		// @property (assign, nonatomic) NSTimeInterval downloadTimeout;
		[Export ("downloadTimeout", ArgumentSemantic.UnsafeUnretained)]
		double DownloadTimeout { get; set; }
	
		// @property (assign, nonatomic) SDWebImageDownloaderExecutionOrder executionOrder;
		[Export ("executionOrder", ArgumentSemantic.UnsafeUnretained)]
		SDWebImageDownloaderExecutionOrder ExecutionOrder { get; set; }
	
		// @property (nonatomic, strong) NSString * username;
		[Export ("username", ArgumentSemantic.Retain)]
		string Username { get; set; }
	
		// @property (nonatomic, strong) NSString * password;
		[Export ("password", ArgumentSemantic.Retain)]
		string Password { get; set; }
	
		// @property (copy, nonatomic) SDWebImageDownloaderHeadersFilterBlock headersFilter;
		[Export ("headersFilter", ArgumentSemantic.Copy)]
		Func<NSUrl, NSDictionary, NSDictionary> HeadersFilter { get; set; }
	
		// +(SDWebImageDownloader *)sharedDownloader;
		[Static, Export ("sharedDownloader")]
		SDWebImageDownloader SharedDownloader ();
	
		// -(void)setValue:(NSString *)value forHTTPHeaderField:(NSString *)field;
		[Export ("setValue:forHTTPHeaderField:")]
		void SetValue (string value, string field);
	
		// -(NSString *)valueForHTTPHeaderField:(NSString *)field;
		[Export ("valueForHTTPHeaderField:")]
		string ValueForHTTPHeaderField (string field);
	
		// -(id<SDWebImageOperation>)downloadImageWithURL:(NSURL *)url options:(SDWebImageDownloaderOptions)options progress:(SDWebImageDownloaderProgressBlock)progressBlock completed:(SDWebImageDownloaderCompletedBlock)completedBlock;
		[Export ("downloadImageWithURL:options:progress:completed:")]
		SDWebImageOperation DownloadImageWithURL (NSUrl url, SDWebImageDownloaderOptions options, Action<int, int> progressBlock, Action<UIImage, NSData, NSError, sbyte> completedBlock);
	
		// -(void)setSuspended:(BOOL)suspended;
		[Export ("setSuspended:")]
		void SetSuspended (bool suspended);
	}

	// @interface SDWebImageDownloaderOperation : NSOperation <SDWebImageOperation>
	[BaseType (typeof (NSOperation))]
	interface SDWebImageDownloaderOperation : SDWebImageOperation {
	
		// -(id)initWithRequest:(NSURLRequest *)request options:(SDWebImageDownloaderOptions)options progress:(SDWebImageDownloaderProgressBlock)progressBlock completed:(SDWebImageDownloaderCompletedBlock)completedBlock cancelled:(SDWebImageNoParamsBlock)cancelBlock;
		[Export ("initWithRequest:options:progress:completed:cancelled:")]
		IntPtr Constructor (NSUrlRequest request, SDWebImageDownloaderOptions options, Action<int, int> progressBlock, Action<UIImage, NSData, NSError, sbyte> completedBlock, Action cancelBlock);
	
		// @property (readonly, nonatomic, strong) NSURLRequest * request;
		[Export ("request", ArgumentSemantic.Retain)]
		NSUrlRequest Request { get; }
	
		// @property (assign, nonatomic) BOOL shouldUseCredentialStorage;
		[Export ("shouldUseCredentialStorage", ArgumentSemantic.UnsafeUnretained)]
		bool ShouldUseCredentialStorage { get; set; }
	
		// @property (nonatomic, strong) NSURLCredential * credential;
		[Export ("credential", ArgumentSemantic.Retain)]
		NSUrlCredential Credential { get; set; }
	
		// @property (readonly, assign, nonatomic) SDWebImageDownloaderOptions options;
		[Export ("options", ArgumentSemantic.UnsafeUnretained)]
		SDWebImageDownloaderOptions Options { get; }
	}
    
    // @protocol SDWebImageOperation <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface SDWebImageOperation {
    
        // @required -(void)cancel;
        [Export ("cancel")]
        [Abstract]
        void Cancel ();
    }
    
   // @interface SDWebImageManager : NSObject
	[BaseType (typeof (NSObject))]
	interface SDWebImageManager {
 
		// @property (nonatomic, weak) id<SDWebImageManagerDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }
 
		// @property (nonatomic, weak) id<SDWebImageManagerDelegate> delegate;
		[Wrap ("WeakDelegate")]
		SDWebImageManagerDelegate Delegate { get; set; }
 
		// @property (readonly, nonatomic, strong) SDImageCache * imageCache;
		[Export ("imageCache", ArgumentSemantic.Retain)]
		SDImageCache ImageCache { get; }
 
		// @property (readonly, nonatomic, strong) SDWebImageDownloader * imageDownloader;
		[Export ("imageDownloader", ArgumentSemantic.Retain)]
		SDWebImageDownloader ImageDownloader { get; }
 
		// @property (copy) SDWebImageCacheKeyFilterBlock cacheKeyFilter;
		[Export ("cacheKeyFilter", ArgumentSemantic.Copy)]
		Func<NSUrl, NSString> CacheKeyFilter { get; set; }
 
		// +(SDWebImageManager *)sharedManager;
		[Static, Export ("sharedManager")]
		SDWebImageManager SharedManager ();
 
		// -(id<SDWebImageOperation>)downloadImageWithURL:(NSURL *)url options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock)progressBlock completed:(SDWebImageCompletionWithFinishedBlock)completedBlock;
		[Export ("downloadImageWithURL:options:progress:completed:")]
		SDWebImageOperation DownloadImageWithURL (NSUrl url, SDWebImageOptions options, Action<int, int> progressBlock, Action<UIImage, NSError, SDImageCacheType, sbyte, NSUrl> completedBlock);
 
		// -(void)saveImageToCache:(UIImage *)image forURL:(NSURL *)url;
		[Export ("saveImageToCache:forURL:")]
		void SaveImageToCache (UIImage image, NSUrl url);
 
		// -(void)cancelAll;
		[Export ("cancelAll")]
		void CancelAll ();
 
		// -(BOOL)isRunning;
		[Export ("isRunning")]
		bool IsRunning ();
 
		// -(BOOL)cachedImageExistsForURL:(NSURL *)url;
		[Export ("cachedImageExistsForURL:")]
		bool CachedImageExistsForURL (NSUrl url);
 
		// -(BOOL)diskImageExistsForURL:(NSURL *)url;
		[Export ("diskImageExistsForURL:")]
		bool DiskImageExistsForURL (NSUrl url);
 
		// -(void)cachedImageExistsForURL:(NSURL *)url completion:(SDWebImageCheckCacheCompletionBlock)completionBlock;
		[Export ("cachedImageExistsForURL:completion:")]
		void CachedImageExistsForURL (NSUrl url, Action<sbyte> completionBlock);
 
		// -(void)diskImageExistsForURL:(NSURL *)url completion:(SDWebImageCheckCacheCompletionBlock)completionBlock;
		[Export ("diskImageExistsForURL:completion:")]
		void DiskImageExistsForURL (NSUrl url, Action<sbyte> completionBlock);
 
		// -(NSString *)cacheKeyForURL:(NSURL *)url;
		[Export ("cacheKeyForURL:")]
		string CacheKeyForURL (NSUrl url);
	}
 
    // @interface SDImageCache : NSObject
	[BaseType (typeof (NSObject))]
	interface SDImageCache {
 
		// -(id)initWithNamespace:(NSString *)ns;
		[Export ("initWithNamespace:")]
		IntPtr Constructor (string ns);
 
		// @property (assign, nonatomic) NSUInteger maxMemoryCost;
		[Export ("maxMemoryCost", ArgumentSemantic.UnsafeUnretained)]
		nuint MaxMemoryCost { get; set; }
 
		// @property (assign, nonatomic) NSInteger maxCacheAge;
		[Export ("maxCacheAge", ArgumentSemantic.UnsafeUnretained)]
		nint MaxCacheAge { get; set; }
 
		// @property (assign, nonatomic) NSUInteger maxCacheSize;
		[Export ("maxCacheSize", ArgumentSemantic.UnsafeUnretained)]
		nuint MaxCacheSize { get; set; }
 
		// +(SDImageCache *)sharedImageCache;
		[Static, Export ("sharedImageCache")]
		SDImageCache SharedImageCache ();
 
		// -(void)addReadOnlyCachePath:(NSString *)path;
		[Export ("addReadOnlyCachePath:")]
		void AddReadOnlyCachePath (string path);
 
		// -(void)storeImage:(UIImage *)image forKey:(NSString *)key;
		[Export ("storeImage:forKey:")]
		void StoreImage (UIImage image, string key);
 
		// -(void)storeImage:(UIImage *)image forKey:(NSString *)key toDisk:(BOOL)toDisk;
		[Export ("storeImage:forKey:toDisk:")]
		void StoreImage (UIImage image, string key, bool toDisk);
 
		// -(void)storeImage:(UIImage *)image recalculateFromImage:(BOOL)recalculate imageData:(NSData *)imageData forKey:(NSString *)key toDisk:(BOOL)toDisk;
		[Export ("storeImage:recalculateFromImage:imageData:forKey:toDisk:")]
		void StoreImage (UIImage image, bool recalculate, NSData imageData, string key, bool toDisk);
 
		// -(NSOperation *)queryDiskCacheForKey:(NSString *)key done:(SDWebImageQueryCompletedBlock)doneBlock;
		[Export ("queryDiskCacheForKey:done:")]
		NSOperation QueryDiskCacheForKey (string key, Action<UIImage, SDImageCacheType> doneBlock);
 
		// -(UIImage *)imageFromMemoryCacheForKey:(NSString *)key;
		[Export ("imageFromMemoryCacheForKey:")]
		UIImage ImageFromMemoryCacheForKey (string key);
 
		// -(UIImage *)imageFromDiskCacheForKey:(NSString *)key;
		[Export ("imageFromDiskCacheForKey:")]
		UIImage ImageFromDiskCacheForKey (string key);
 
		// -(void)removeImageForKey:(NSString *)key;
		[Export ("removeImageForKey:")]
		void RemoveImageForKey (string key);
 
		// -(void)removeImageForKey:(NSString *)key withCompletion:(SDWebImageNoParamsBlock)completion;
		[Export ("removeImageForKey:withCompletion:")]
		void RemoveImageForKey (string key, Action completion);
 
		// -(void)removeImageForKey:(NSString *)key fromDisk:(BOOL)fromDisk;
		[Export ("removeImageForKey:fromDisk:")]
		void RemoveImageForKey (string key, bool fromDisk);
 
		// -(void)removeImageForKey:(NSString *)key fromDisk:(BOOL)fromDisk withCompletion:(SDWebImageNoParamsBlock)completion;
		[Export ("removeImageForKey:fromDisk:withCompletion:")]
		void RemoveImageForKey (string key, bool fromDisk, Action completion);
 
		// -(void)clearMemory;
		[Export ("clearMemory")]
		void ClearMemory ();
 
		// -(void)clearDiskOnCompletion:(SDWebImageNoParamsBlock)completion;
		[Export ("clearDiskOnCompletion:")]
		void ClearDiskOnCompletion (Action completion);
 
		// -(void)clearDisk;
		[Export ("clearDisk")]
		void ClearDisk ();
 
		// -(void)cleanDiskWithCompletionBlock:(SDWebImageNoParamsBlock)completionBlock;
		[Export ("cleanDiskWithCompletionBlock:")]
		void CleanDiskWithCompletionBlock (Action completionBlock);
 
		// -(void)cleanDisk;
		[Export ("cleanDisk")]
		void CleanDisk ();
 
		// -(NSUInteger)getSize;
		[Export ("getSize")]
		nuint GetSize ();
 
		// -(NSUInteger)getDiskCount;
		[Export ("getDiskCount")]
		nuint GetDiskCount ();
 
		// -(void)calculateSizeWithCompletionBlock:(SDWebImageCalculateSizeBlock)completionBlock;
		[Export ("calculateSizeWithCompletionBlock:")]
		void CalculateSizeWithCompletionBlock (Action<uint, uint> completionBlock);
 
		// -(void)diskImageExistsWithKey:(NSString *)key completion:(SDWebImageCheckCacheCompletionBlock)completionBlock;
		[Export ("diskImageExistsWithKey:completion:")]
		void DiskImageExistsWithKey (string key, Action<sbyte> completionBlock);
 
		// -(BOOL)diskImageExistsWithKey:(NSString *)key;
		[Export ("diskImageExistsWithKey:")]
		bool DiskImageExistsWithKey (string key);
 
		// -(NSString *)cachePathForKey:(NSString *)key inPath:(NSString *)path;
		[Export ("cachePathForKey:inPath:")]
		string CachePathForKey (string key, string path);
 
		// -(NSString *)defaultCachePathForKey:(NSString *)key;
		[Export ("defaultCachePathForKey:")]
		string DefaultCachePathForKey (string key);
	}
}
