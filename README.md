<a name="readme-top"></a>

<!-- PROJECT SHIELDS -->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <!-- <a href="https://github.com/heronet/GoodWillApi">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a> -->
  
  <h3 align="center" style="font-size: 25px">GoodWill Backend</h3>

  <p align="center">
    The social media platform!
    <br />
    <a href="https://goodwillweb.vercel.app"><strong>See it live »</strong></a>
    <br />
    <br />
    <a href="https://goodwillweb.vercel.app">View Demo</a>
    ·
    <a href="https://github.com/heronet/GoodWillApi/issues">Report Bug</a>
    ·
    <a href="https://github.com/heronet/GoodWillApi/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->

## About The Project

GoodWill is a volunteer platform. It is a two part project. This is the `Backend`. The `Frontend` can be found [here](https://github.com/heronet/GoodWillApi).

- GoodWill uses `ASP.Net Core` for the `Backend` and `SvelteKit` for the `Frontend`. It uses `PostgreSQL` as the database.
- The `Backend` uses `Docker` which is hosted on `Google Cloud Run`.

<!-- SCREENSHOT -->

<!-- [![GoodWillApi Screen Shot][screenshot]](https://GoodWillApi-si.web.app) -->

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

- [![SvelteKit][SvelteKit]][sveltekit-url]
- [![Dotnet][dotnet.microsoft.com]][dotnet-url]
- [![PostgreSQL][postgresql.org]][postgresql-url]
- [![Docker][docker.io]][docker-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisits

> Docker and Docker Compose must be installed.

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/heronet/GoodwillApi.git
   ```
2. Rename `.env.local` to `.env` and fill in the Environment Variables with your credentials.

3. Run the project
   ```sh
   docker compose up --build
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ROADMAP -->

## Roadmap

- [x] Add blood donation
- [x] Add volunteer
- [x] Add Google maps API
- [x] Add profile page
- [x] Add logs page

See the [open issues](https://github.com/heronet/GoodWillApi/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->

## License

Distributed under the GPLv3 License. See `LICENSE` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->

## Contact

Sirat - sirat4757@gmail.com

Project Link: [https://github.com/heronet/GoodWillApi](https://github.com/heronet/GoodWillApi)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->

## Acknowledgments

- [Img Shields](https://shields.io)
- [Font Awesome](https://fontawesome.com)
- [Othneildrew](https://github.com/othneildrew/Best-README-Template)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/heronet/GoodWillApi.svg?style=for-the-badge
[contributors-url]: https://github.com/heronet/GoodWillApi/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/heronet/GoodWillApi.svg?style=for-the-badge
[forks-url]: https://github.com/heronet/GoodWillApi/network/members
[stars-shield]: https://img.shields.io/github/stars/heronet/GoodWillApi.svg?style=for-the-badge
[stars-url]: https://github.com/heronet/GoodWillApi/stargazers
[issues-shield]: https://img.shields.io/github/issues/heronet/GoodWillApi.svg?style=for-the-badge
[issues-url]: https://github.com/heronet/GoodWillApi/issues
[license-shield]: https://img.shields.io/github/license/heronet/GoodWillApi.svg?style=for-the-badge
[license-url]: https://github.com/heronet/GoodWillApi/blob/main/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/siratul-islam
[screenshot]: images/scr.png
[angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[sveltekit-url]: https://kit.svelte.dev/
[dotnet.microsoft.com]: https://img.shields.io/badge/Dotnet-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[dotnet-url]: https://dotnet.microsoft.com/
[postgresql.org]: https://img.shields.io/badge/Postgresql-4169E1?style=for-the-badge&logo=postgresql&logoColor=white
[postgresql-url]: https://postgresql.org/
[docker.io]: https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white
[docker-url]: https://docker.io/
[SvelteKit]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte
