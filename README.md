# N_TierSolutionGenerator

## Genel Bakış

**N-Tier Proje Oluşturucusu**, N-Tier mimarisine sahip bir çözümü hızlı ve kolay bir şekilde oluşturmanızı sağlayan bir Visual Studio eklentisidir. Bu eklenti, Entity, DataAccess, Business, Core, WebAPI ve MVC Web projeleri gibi yaygın katmanların kurulumunu otomatikleştirir, bu sayede projelerinizde en iyi uygulamalara uygun yapılarla başlarsınız.

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

1. **Yeni Bir N-Tier Çözümü Oluşturma**:
   - Visual Studio'yu açın ve yeni bir boş proje oluşturun.
   - `Araçlar > N-Tier Ekle` menüsüne gidin.
   - Eklenti, tam bir N-Tier çözüm yapısını otomatik olarak oluşturacaktır.

2. **Çözüm Yapısını Anlama**:
   - **Entity Katmanı**: Varlık sınıflarını ve DTO'ları içerir.
   - **DataAccess Katmanı**: Repository arayüzlerini ve Entity Framework uygulamalarını içerir.
   - **Business Katmanı**: Hizmet arayüzlerini, uygulamaları ve iş mantığını içerir.
   - **Core Katmanı**: Günlük kaydı, önbellekleme, doğrulama ve güvenlik gibi çapraz kesitli endişeleri içerir.
   - **WebAPI Katmanı**: API kontrolörlerini ve başlangıç yapılandırmalarını içerir.
   - **Web Katmanı**: MVC kontrolörlerini, görünümleri, modelleri ve başlangıç yapılandırmalarını içerir.

3. **Çözümü Genişletme**:
   - Yeni varlıklar, hizmetler ve kontrolörler ekleyerek çözümü kolayca genişletebilirsiniz. Önceden yapılandırılmış şablonlar, çözüm genelinde tutarlılığı sağlar.
  
     
 Katkıda Bulunma
Katkılarınızı bekliyoruz! Eğer iyileştirme önerileriniz varsa veya herhangi bir sorunla karşılaşırsanız, lütfen bir issue açın veya bir pull request gönderin.

Lisans
Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına bakın.

İletişim
Sorularınız veya destek talepleriniz için profilimdeki iletişim adreslerimden ile iletişime geçebilirsiniz.
