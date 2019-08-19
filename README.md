# Blazor Tweet Button [![NuGet Package](https://img.shields.io/nuget/v/Toolbelt.Blazor.TwitterShareButton.svg)](https://www.nuget.org/packages/Toolbelt.Blazor.TwitterShareButton/)

## Summary

A Tweet Button component for Blazor.

## How to install and use?

### 1. Installation and Registration

**Step.1-1** Install the library via NuGet package, like this.

```shell
> dotnet add package Toolbelt.Blazor.TwitterShareButton
```

**Step.1-2** Open name space, like this.

```csharp
// _Imports.razor
...
@using Toolbelt.Blazor.TwitterShareButton
```

### 2. Usage in your Blazor component (.razor)

You can use `TwitterShareButton` component.

If you implement your component like this,

```html
<TwitterShareButton 
  Text="@($"Current Count is {currentCount}")"
  Size="Large"></TwitterShareButton>
```

Then you will get this.

![fig.1](https://raw.githubusercontent.com/jsakamoto/Toolbelt.Blazor.TwitterShareButton/master/.assets/fig1.png)

## Release Note

- **v.5.0.0** - BREAKING CHANGE: Support Blazor v.3.0.0 Preview 8 (not compatible with v.3.0.0 Preview 4 or before.)
- **v.4.0.0** - BREAKING CHANGE: Support Blazor v.3.0.0 Preview 4 (not compatible with v.0.9.0 or before.)
- **v.3.0.0** - BREAKING CHANGE: Support Blazor v.0.9.0 (not compatible with v.0.8.0 or before.)
- **v.2.0.0** - BREAKING CHANGE: Support Blazor v.0.8.0 (not compatible with v.0.7.0 or before.)
- **v.1.0.1** - Suppressed the flicker that occurs when parameters are updated.
- **v.1.0.0** - 1st release.


## License

[Mozilla Public License Version 2.0](https://github.com/jsakamoto/Toolbelt.Blazor.TwitterShareButton/blob/master/LICENSE)