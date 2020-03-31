# Powerpoint Accessories

> A .net core library to scan Powerpoint presentations (pptx) for common Audio Visual/presentational issues such as auto transitions and video issues. 

## Table of Contents

- [Installation](#installation)
- [Features](#features)
- [Contributing](#contributing)
- [FAQ](#faq)
- [License](#license)


---

## Example

```C#

powerpoint = PowerpointFactory.GetPowerpoint(dir);
scanner = IssueScannerFactory.GetIssueScanner(powerpoint);
scanner.Scan();
Dictionary<string, SlideModel> slides = (Dictionary<string, SlideModel>)powerpoint.slides;
foreach (KeyValuePair<string, SlideModel> slide in slides)
{
    if (slide.Value.Issues.Count != 0)
    {
      slide.Value.Issues.ForEach(x => Console.WriteLine($"{x.GetType()} {x.Description}"));
    }
    else
    {
      Console.WriteLine($"{slide.Value.slideId} has no issues");
    }
```

---

## Installation
- The repo contains three projects for visual studio. PowerpointAccessories is the library project, NUnitTests is the tests and the Run project is used to interface with the library package through command line.

### Setup

> clone this repo and build using .net core cli

```shell
$ dotnet build
```

---

## Features

- Scan pptx file for Auto Transistion, video and no click issues.
- CLI to use library stand alone when not incorporating into software

---

## Contributing

> To get started...

### Step 1

- **Option 1**
    - 🍴 Fork this repo!

- **Option 2**
    - 👯 Clone this repo to your local machine using `https://github.com/adamrcarter/PowerpointAccessories.git`

### Step 2

- **HACK AWAY!** 🔨🔨🔨

### Step 3

- 🔃 Create a new pull request

---

## FAQ


---


## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
- Copyright 2015 © Adam Carter
