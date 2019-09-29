# Blazor Tweet Button [![NuGet Package](https://img.shields.io/nuget/v/Toolbelt.Blazor.TwitterShareButton.svg)](https://www.nuget.org/packages/Toolbelt.Blazor.TwitterShareButton/)

## Summary

A Tweet Button component for Blazor.

This component supports **both server-side Blazor Server App and client-side Blazor WebAssembly App**.

## How to install and use?

### 1. Installation and Registration

**Step.1-1** Install the library via NuGet package, like this.

```shell
> dotnet add package Toolbelt.Blazor.TwitterShareButton
```

**Step.1-2** Open namespace, like this.

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
  Size="Large">
</TwitterShareButton>
```

Then you will get this.

![fig.1](https://raw.githubusercontent.com/jsakamoto/Toolbelt.Blazor.TwitterShareButton/master/.assets/fig1.png)

## Appendix - bundled support JavaScript

`TwitterShareButton` component automatically inject a reference of the support JavaScript file which is bundled with this NuGet package into `<head>` element of the current document.

The support JavaScript file is deployed at the URL "_content/Toolbelt.Blazor.TwitterShareButton/script.js".

If you want to disable this behavior, you can configure it in one of the following ways:

### a. "DisableClientScriptAutoInjection" property of the "TwitterShareButton" component

You can disable automatic injection of a reference of the support JavaScript file by "DisableClientScriptAutoInjection" property of the "TwitterShareButton" component.

If you set to `false` the "DisableClientScriptAutoInjection" property of the "TwitterShareButton" component, the "TwitterShareButton" doesn't inject a reference of the support JavaScript file.

```html
<TwitterShareButton Text="..."
  DisableClientScriptAutoInjection="false">
</TwitterShareButton>
```

### b. Configure global options for "TwitterShareButton" at "Startup" class

You can also disable automatic injection of a reference of the support JavaScript file by configure global options for "TwitterShareButton" at "Startup" class, like this.

```csharp
...
using Toolbelt.Blazor.Extensions.DependencyInjection; // <- Add this...

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    // ...and add flollow lines.
    services.AddTwitterShareButtonGlobalOptions(options =>
    {
       options.DisableClientScriptAutoInjection = false;
    });
   ...
```

### Note

#### (a)

Disabling "automatic injection" by configure global options way is more high priority than the "DisableClientScriptAutoInjection" property of the "TwitterShareButton" component.

If you configure global options "DisableClientScriptAutoInjection" to be true, then "automatic injection" never work even if set the "DisableClientScriptAutoInjection" property of the "TwitterShareButton" component to `false` explicity.

#### (b)

If you disable "automatic injection", Adding a reference to the support JavaScript file is a responsibility of you.

For example, you can do it by editing "index.html" and add `<script>` tag statically like following:

```html
<!DOCTYPE html>
<html>
<head>
  ...
  <script src="_content/Toolbelt.Blazor.TwitterShareButton/script.js"></script>
```

## Release Note

- **v.7.0.0**
  - Support Server-side Blazor Server app.
  - Made automatic injection of a reference of the support file is configurable.
- **v.6.0.0** - BREAKING CHANGE: Support Blazor v.3.0.0 Preview 9 (not compatible with v.3.0.0 Preview 8 or before.)
- **v.5.0.0** - BREAKING CHANGE: Support Blazor v.3.0.0 Preview 8 (not compatible with v.3.0.0 Preview 4 or before.)
- **v.4.0.0** - BREAKING CHANGE: Support Blazor v.3.0.0 Preview 4 (not compatible with v.0.9.0 or before.)
- **v.3.0.0** - BREAKING CHANGE: Support Blazor v.0.9.0 (not compatible with v.0.8.0 or before.)
- **v.2.0.0** - BREAKING CHANGE: Support Blazor v.0.8.0 (not compatible with v.0.7.0 or before.)
- **v.1.0.1** - Suppressed the flicker that occurs when parameters are updated.
- **v.1.0.0** - 1st release.


## License

[Mozilla Public License Version 2.0](https://github.com/jsakamoto/Toolbelt.Blazor.TwitterShareButton/blob/master/LICENSE)