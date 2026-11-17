# DOTween for Unity Package Manager

An unofficial UPM package of DOTween **1.3.045** by Demigiant. The package version
is `1.3.45` because SemVer does not allow leading zeros in the patch number.
The declared minimum Unity version is **2021.3**.

## Install from Git

Once the UPM package files have been pushed to this repository:

1. Open **Window > Package Manager** in Unity.
2. Select **+ > Add package from git URL...** (or **Install package from Git URL...** in newer versions).
3. Enter this repository's URL:

   ```text
   https://github.com/PavelFoxx/DOTween.git
   ```

This URL matches the repository's `origin` remote. No `?path=` parameter is
required because `package.json` is at the repository root.
To pin a version, append an existing Git tag or commit hash:

```text
https://github.com/PavelFoxx/DOTween.git#v1.3.45
```

Create and push the `v1.3.45` tag when publishing that release.
Alternatively, add the following entry to `dependencies` in your **project's**
`Packages/manifest.json`:

```json
"com.demigiant.dotween": "https://github.com/PavelFoxx/DOTween.git#v1.3.45"
```

Unity must have access to Git and the repository. For a private repository,
configure Git authentication on developer machines and in CI.
Before installing, remove any previous DOTween copy from `Assets` to avoid
duplicate DLLs and module classes. Keep your existing `DOTweenSettings.asset`
in `Assets/Resources` if you want to preserve its settings.

## Install locally

In Package Manager, select **Add package from disk...** and choose this
repository's `package.json`. You can also add the package to your project's
`Packages/manifest.json` using a local path:

```json
"com.demigiant.dotween": "file:D:/ProjectFiles/DOTween"
```

Replace the path with the location of your local checkout.

## Usage

```csharp
using DG.Tweening;
using UnityEngine;

public class TweenExample : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveX(5f, 1f).SetLoops(2, LoopType.Yoyo);
    }
}
```

The package includes the precompiled `DOTween.dll` and the `DOTween.Modules`
assembly. Audio, Physics, Physics2D, Sprite, and uGUI modules are enabled by
default, and their Unity dependencies are declared in the package manifest.
You do not need to generate assembly definitions after installation.
If your code uses its own `.asmdef`, add a reference to `DOTween.Modules`.
If **Override References** is enabled, also add `DOTween.dll` to
**Assembly References**.

Open **Tools > Demigiant > DOTween Settings** to create or select
`Assets/Resources/DOTweenSettings.asset`, then edit its properties in the
Inspector. Existing settings assets are preserved. DOTween uses its defaults
if no settings asset exists.

To enable UI Toolkit, add `DOTWEEN_UITOOLKIT` to **Scripting Define Symbols**
in Player Settings for the relevant platforms. To disable standard modules,
use `DOTWEEN_NOAUDIO`, `DOTWEEN_NOPHYSICS`, `DOTWEEN_NOPHYSICS2D`,
`DOTWEEN_NOSPRITES`, or `DOTWEEN_NOUI`. The legacy Asset Store setup fields
do not control module compilation in this package.

EPOOutline integration requires the separate third-party asset and references
to its assemblies in `DOTween.Modules`. It is disabled by default.
To change assembly references in a Git package, use your own repository fork
or embed the package in your project.

## Package layout and updates

- `package.json` contains the UPM manifest.
- `Runtime/` contains the DOTween DLL and module sources with a shared assembly definition.
- `Editor/` contains editor tools and images.
- `readme.txt` contains Demigiant's original instructions.

The contents of the original DLLs, scripts, and resources are unchanged.
The original `DOTweenEditor.dll` and `DOTweenUpgradeManager.dll` are retained
but disabled through Plugin Importer settings. In DOTween 1.3.045, the original
editor incorrectly treats the UPM cache under `Library/PackageCache` as an
installation under `Assets`. The upgrade helper also expects to modify and
delete installation files.

Instead, this package includes a small `DOTween.UPM.Editor` assembly with a
settings menu and Inspector. The original Utility Panel, editor preview, and
other windows supplied by the original editor DLL are unavailable in this
package. `DOTween.dll` is enabled in both the editor and player builds.

When updating DOTween, replace the upstream files, preserve their `.meta`
files, update the version in `package.json` and `CHANGELOG.md`, verify the
import, and create a new Git tag.

This package was tested with Unity **6000.3.9f1**. Compatibility with the
declared minimum version, Unity 2021.3, has not been tested separately.

## License and documentation

DOTween belongs to Daniele Giardini / Demigiant and is subject to the
[original DOTween license](https://dotween.demigiant.com/license.php).
See [LICENSE.md](LICENSE.md) and the [original readme](readme.txt).
This package is not an official Demigiant release.

- [DOTween documentation](https://dotween.demigiant.com/documentation.php)
- [Unity: Creating custom packages](https://docs.unity3d.com/2021.3/Documentation/Manual/CustomPackages.html)
- [Unity: Git dependencies](https://docs.unity3d.com/2021.3/Documentation/Manual/upm-git.html)
