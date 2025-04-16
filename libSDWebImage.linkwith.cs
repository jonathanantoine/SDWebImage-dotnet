using ObjCRuntime;

[assembly: LinkWith ("libSDWebImage.a", LinkTarget.Arm64 | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, 
    LinkerFlags = "-ObjC -fobjc-arc", Frameworks = "CoreGraphics ImageIO QuartzCore Foundation", SmartLink = true, ForceLoad = true)]
    