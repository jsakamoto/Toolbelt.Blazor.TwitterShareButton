# Blazor Tweet Button [![NuGet Package](https://img.shields.io/nuget/v/Toolbelt.Blazor.TwitterShareButton.svg)](https://www.nuget.org/packages/Toolbelt.Blazor.TwitterShareButton/)

## Summary

A Tweet Button component  for Blazor.

## How to install and use?

### 1. Installation and Registration

**Step.1-1** Install the library via NuGet package, like this.

```shell
> dotnet add package Toolbelt.Blazor.TwitterShareButton
```

**Step.1-2** Register tag helper to your Blazor app, like this.

```csharp
// _ViewImports.cshtml
...
@addTagHelper *, Toolbelt.Blazor.TwitterShareButton
```

### 2. Usage in your Blazor component (.cshtml)

You can use `TwitterShareButton` component.

If you implement your component like this,

```html
<TwitterShareButton 
  Text="@($"Current Count is {currentCount}")"
  Size="Large"></TwitterShareButton>
```

Then you will get this.

![fig.1](https://raw.githubusercontent.com/jsakamoto/Toolbelt.Blazor.TwitterShareButton/master/.assets/fig1.png)

## License

[Mozilla Public License Version 2.0](https://github.com/jsakamoto/Toolbelt.Blazor.TwitterShareButton/blob/master/LICENSE)