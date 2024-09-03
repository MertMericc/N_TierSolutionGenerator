# N_TierSolutionGenerator TR

## Genel Bakış

**N-Tier Proje Oluşturucusu**, N-Tier mimarisine sahip bir çözümü hızlı ve kolay bir şekilde oluşturmanızı sağlayan bir Visual Studio eklentisidir. Bu eklenti, Entity, DataAccess, Business, Core, WebAPI ve MVC Web projeleri gibi yaygın katmanların kurulumunu otomatikleştirir, böylece projelerinizde en iyi uygulamalara uygun yapılarla başlarsınız. 

- **"Create N-Tier Architecture"** butonu, `Tools` menüsü altında bulunur. Bu buton ile, yeni bir N-Tier çözüm yapısı otomatik olarak oluşturulur.
- **"Sync Entity Across Layers"** butonu ise `ItemNodeGroup` menüsü içinde yer alır. Bu buton, bir entity'yi tüm ilgili katmanlar arasında senkronize eder. `Solution Explorer` içinde bir entity dosyasına sağ tıkladığınızda bu seçenek görünür ve seçilen entity'ye ait dosyalar ve sınıflar otomatik olarak Entity, DataAccess ve Business katmanlarına eklenir.

## Özellikler

- **Otomatik Proje Kurulumu**: Entity, DataAccess, Business, Core, WebAPI ve Web projeleriyle tam bir N-Tier çözüm yapısını anında oluşturun.
- **Katmanlı Mimari**: Kodlarınızın temiz, modüler ve bakımı kolay olmasını sağlayan net bir katmanlı mimari sunar.
- **Proje Referansları**: Katmanlar arası iletişimi sağlamak için gerekli proje referanslarını otomatik olarak ekler.
- **MVC ve WebAPI Hazırlığı**: MVC ve WebAPI projeleri için önceden yapılandırılmış şablonlarla birlikte gelir, böylece zaman kaybetmeden geliştirmeye başlayabilirsiniz.
- **Entity ve DataAccess Katmanları**: Varlık modelleri ve veri erişim katmanlarını, repository desenleri ve Entity Framework entegrasyonu ile kolayca oluşturun.
- **Core Katmanı Yardımcıları**: Günlük kaydı, önbellekleme, doğrulama ve güvenlik gibi çapraz kesitli endişeleri içeren temel yardımcı sınıflar sağlar.

## Kurulum

N-Tier Proje Oluşturucusu'nu kurmak için şu adımları izleyin:

1. GitHub deposundan projeyi indirin.
2. Visual Studio'yu açın ve `Uzantılar > Uzantıları Yönet` menüsüne gidin.
3. `VSIX'ten Yükle` seçeneğine tıklayın ve indirdiğiniz eklentiyi seçin.
4. Kurulum tamamlandıktan sonra Visual Studio'yu yeniden başlatın.

## Kullanım

### 1. Yeni Bir N-Tier Çözümü Oluşturma
- Visual Studio'yu açın ve yeni bir boş proje oluşturun.
- `Araçlar > Create N-Tier Architecture` menüsüne gidin.
- Eklenti, tam bir N-Tier çözüm yapısını otomatik olarak oluşturacaktır.

### 2. Bir Entity'yi Tüm Katmanlara Entegre Etme
- `Solution Explorer`'da entegre etmek istediğiniz entity dosyasına sağ tıklayın.
- `Sync Entity Across Layers` seçeneğini seçin.
- Eklenti, ilgili entity için Entity, DataAccess ve Business katmanlarında gerekli dosyaları otomatik olarak oluşturur ve günceller.

### 3. Çözüm Yapısını Anlama

- **Entity Katmanı**: Varlık sınıflarını ve DTO'ları içerir.
- **DataAccess Katmanı**: Repository arayüzlerini ve Entity Framework uygulamalarını içerir.
- **Business Katmanı**: Hizmet arayüzlerini, uygulamaları ve iş mantığını içerir.
- **Core Katmanı**: Günlük kaydı, önbellekleme, doğrulama ve güvenlik gibi çapraz kesitli endişeleri içerir.
- **WebAPI Katmanı**: API kontrolörlerini ve başlangıç yapılandırmalarını içerir.
- **Web Katmanı**: MVC kontrolörlerini, görünümleri, modelleri ve başlangıç yapılandırmalarını içerir.

### 4. Çözümü Genişletme
- Yeni entity'ler, hizmetler ve kontrolörler ekleyerek çözümü kolayca genişletebilirsiniz. Önceden yapılandırılmış şablonlar, çözüm genelinde tutarlılığı sağlar.

## Katkıda Bulunma

Katkılarınızı bekliyoruz! Eğer iyileştirme önerileriniz varsa veya herhangi bir sorunla karşılaşırsanız, lütfen bir issue açın veya bir pull request gönderin.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına bakın.

## İletişim

Sorularınız veya destek talepleriniz için profilimdeki iletişim adreslerimden bana ulaşabilirsiniz.


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# N_TierSolutionGenerator EN

## Overview

**N-Tier Project Generator** is a Visual Studio extension that allows you to quickly and easily create a solution with an N-Tier architecture. This extension automates the setup of common layers such as Entity, DataAccess, Business, Core, WebAPI, and MVC Web projects, ensuring that your projects start with structures aligned with best practices.

- **"Create N-Tier Architecture"** button is located under the `Tools` menu. Clicking this button automatically generates a new N-Tier solution structure.
- **"Sync Entity Across Layers"** button is found within the `ItemNodeGroup` menu. This button synchronizes an entity across all relevant layers. When you right-click an entity file in the `Solution Explorer`, this option becomes available. Selecting it automatically adds the necessary files and classes related to the selected entity to the Entity, DataAccess, and Business layers.

## Features

- **Automated Project Setup**: Instantly create a complete N-Tier solution structure with Entity, DataAccess, Business, Core, WebAPI, and Web projects.
- **Layered Architecture**: Provides a clear layered architecture that ensures your code is clean, modular, and easy to maintain.
- **Project References**: Automatically adds the necessary project references to facilitate communication between layers.
- **MVC and WebAPI Preparedness**: Comes with pre-configured templates for MVC and WebAPI projects, allowing you to start development without delay.
- **Entity and DataAccess Layers**: Easily create entity models and data access layers with repository patterns and Entity Framework integration.
- **Core Layer Helpers**: Provides essential helper classes for cross-cutting concerns such as logging, caching, validation, and security.

## Installation

To install the N-Tier Project Generator, follow these steps:

1. Download the project from the GitHub repository.
2. Open Visual Studio and navigate to `Extensions > Manage Extensions`.
3. Click on the `Install from VSIX` option and select the downloaded extension.
4. After the installation is complete, restart Visual Studio.

## Usage

### 1. Creating a New N-Tier Solution
- Open Visual Studio and create a new blank project.
- Go to `Tools > Create N-Tier Architecture`.
- The extension will automatically generate a complete N-Tier solution structure.

### 2. Integrating an Entity Across All Layers
- Right-click on the entity file you wish to integrate in the `Solution Explorer`.
- Select the `Sync Entity Across Layers` option.
- The extension will automatically create and update the necessary files in the Entity, DataAccess, and Business layers for the selected entity.

### 3. Understanding the Solution Structure

- **Entity Layer**: Contains entity classes and DTOs.
- **DataAccess Layer**: Contains repository interfaces and Entity Framework implementations.
- **Business Layer**: Contains service interfaces, implementations, and business logic.
- **Core Layer**: Contains cross-cutting concerns such as logging, caching, validation, and security.
- **WebAPI Layer**: Hosts your RESTful APIs. API controllers are defined in this layer.
- **Web Layer**: Contains MVC controllers, views, models, and startup configurations.

### 4. Extending the Solution
- Easily extend the solution by adding new entities, services, and controllers. Pre-configured templates ensure consistency across the entire solution.

## Contributing

We welcome your contributions! If you have suggestions for improvements or encounter any issues, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

## Contact

For any questions or support requests, feel free to reach out through the contact information available in my profile.

