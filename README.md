# Maui iOS binding for SDWebImage

[![NuGet version](https://badge.fury.io/nu/com.jonathanantoine.SDWebImage.svg)](https://badge.fury.io/nu/com.jonathanantoine.SDWebImage)

- Native library: [SDWebImage](https://github.com/SDWebImage/SDWebImage)

**Support Net 9.0 for iOS (works with Xcode 15 and iOS 17)**

## Nuget

* `Install-Package com.jonathanantoine.SDWebImage`
* <https://www.nuget.org/packages/com.jonathanantoine.SDWebImage>

## Build

* Run the github action to build the project


## Usage

```csharp
using SDWebImage;

// Creeate imageView or loaded from XIB
var imageView = new UIImageView();

// Download or usage cached image by url
imageView.SetImage(NSUrl.FromString(url));
```

## Contribution

Contribution to [ApiDefinition.cs](ApiDefinition.cs) are welcome, just send PRs.

This is initialy a fork from https://github.com/trinnguyen/SDWebImage-Xamarin

## History
The Xamarin's team binding project is still available but no more maintenance is done : https://github.com/xamarin/XamarinComponents/blob/main/iOS/SDWebImage/source/SDWebImage/StructsAndEnums.cs