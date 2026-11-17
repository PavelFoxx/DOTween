# DOTween для Unity Package Manager

Неофициальная UPM-упаковка DOTween **1.3.045** от Demigiant. Версия пакета —
`1.3.45`: SemVer не допускает ведущие нули в номере patch.
Минимальная заявленная версия Unity — **2021.3**.

## Установка через Git

После публикации этого репозитория на Git-сервере:

1. Откройте **Window > Package Manager** в Unity.
2. Нажмите **+ > Add package from git URL…** (в новых версиях — **Install package from Git URL…**).
3. Вставьте URL **этого** репозитория, например:

   ```text
   https://github.com/PavelFoxx/DOTween.git
   ```

Адрес соответствует `origin` этого репозитория. Установка станет доступна
после отправки изменений UPM на сервер. `?path=` не нужен — `package.json`
находится в корне.
Для закрепления версии используйте существующий Git-тег или хеш коммита:

```text
https://github.com/PavelFoxx/DOTween.git#v1.3.45
```

Тег `v1.3.45` нужно создать и отправить на сервер при публикации.
Альтернатива — добавить запись в `dependencies` файла **проекта** `Packages/manifest.json`:

```json
"com.demigiant.dotween": "https://github.com/PavelFoxx/DOTween.git#v1.3.45"
```

Unity должен иметь доступ к Git и репозиторию; для приватного репозитория
настройте Git-аутентификацию на компьютере разработчика и в CI.
Перед установкой удалите прежнюю копию DOTween из `Assets`, чтобы избежать
дублирования DLL и классов модулей. Сохраните существующий `DOTweenSettings.asset`
в `Assets/Resources`, если хотите перенести настройки.

## Локальная проверка

В Package Manager выберите **Add package from disk…** и укажите
`package.json` из этого каталога. Также можно подключить пакет через
`Packages/manifest.json` проекта:

```json
"com.demigiant.dotween": "file:D:/ProjectFiles/DOTween"
```

## Использование

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

Пакет содержит готовую `DOTween.dll` и сборку `DOTween.Modules`.
Модули Audio, Physics, Physics2D, Sprite и uGUI включены по умолчанию;
зависимости Unity указаны в манифесте. Генерировать ASMDEF после установки
не требуется. Если ваш код находится в собственной сборке `.asmdef`, добавьте
ссылку на `DOTween.Modules`. При включённом **Override References** также
добавьте `DOTween.dll` в **Assembly References**.

Настройки: **Tools > Demigiant > DOTween Settings**. Меню создаёт или открывает
`Assets/Resources/DOTweenSettings.asset`; параметры изменяются в Inspector.
Готовый settings-asset используется без перезаписи. DOTween работает с настройками
по умолчанию, если этот asset не создан.

Для UI Toolkit добавьте `DOTWEEN_UITOOLKIT` в **Scripting Define Symbols**
в Player Settings для нужных платформ. Для отключения стандартных модулей
используйте `DOTWEEN_NOAUDIO`, `DOTWEEN_NOPHYSICS`, `DOTWEEN_NOPHYSICS2D`,
`DOTWEEN_NOSPRITES`, `DOTWEEN_NOUI`. Поля старого Asset Store setup не управляют
компиляцией модулей этой упаковки.
Интеграция EPOOutline требует отдельного стороннего ассета и ссылок на его
сборки в `DOTween.Modules`; она выключена по умолчанию. Для изменения ссылок
в Git-пакете используйте собственную копию репозитория или embedded-пакет.

## Структура и обновления

- `package.json` — манифест UPM.
- `Runtime/` — DLL DOTween и исходники модулей с общей сборкой.
- `Editor/` — инструменты редактора и изображения.
- `readme.txt` — исходная инструкция Demigiant.

Исходные DLL, скрипты и ресурсы сохранены без изменения содержимого.
Оригинальные `DOTweenEditor.dll` и `DOTweenUpgradeManager.dll` сохранены,
но отключены настройками Plugin Importer. В DOTween 1.3.045 штатный редактор
ошибочно принимает UPM-кеш внутри `Library/PackageCache` за установку в `Assets`;
помощник обновления также рассчитан на изменение и удаление файлов установки.
Вместо них пакет содержит небольшую редакторскую сборку `DOTween.UPM.Editor`
с меню настроек и Inspector. Оригинальная Utility Panel, редакторский preview
и вспомогательные окна штатной DLL в этой упаковке недоступны.
`DOTween.dll` доступна в редакторе и в сборках игры.

При обновлении замените исходные файлы, сохраните `.meta`, обновите версию
в `package.json` и `CHANGELOG.md`, проверьте импорт и создайте новый Git-тег.

Проверка этой упаковки выполняется в Unity **6000.3.9f1**. Совместимость
с минимальной заявленной Unity 2021.3 отдельно не проверялась.

## Лицензия и документация

DOTween принадлежит Daniele Giardini / Demigiant. Применяется
[оригинальная лицензия DOTween](https://dotween.demigiant.com/license.php),
см. [LICENSE.md](LICENSE.md) и [исходный readme](readme.txt).
Эта упаковка не является официальным релизом Demigiant.

- [Документация DOTween](https://dotween.demigiant.com/documentation.php)
- [Unity: создание пакетов](https://docs.unity3d.com/2021.3/Documentation/Manual/CustomPackages.html)
- [Unity: Git-зависимости](https://docs.unity3d.com/2021.3/Documentation/Manual/upm-git.html)
