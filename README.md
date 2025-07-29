# 🧪 Anselme.Webtest

**Anselme.Webtest** é uma solução de testes automatizados em .NET Core 3.1 utilizando Selenium WebDriver e o padrão **Page Object**, uma das abordagens mais recomendadas para criação de testes de interface. Este projeto foi pensado para reduzir linhas de código, aumentar a legibilidade e facilitar a manutenção dos testes — especialmente em aplicações como SPAs (Single Page Applications), incluindo aquelas feitas com AngularJS.

---

## 🧠 Sobre o padrão Page Object

O padrão **Page Object** foi descrito por [Martin Fowler](https://martinfowler.com/bliki/PageObject.html) e é amplamente adotado na automação de testes de UI. A ideia central é encapsular a lógica de interação com elementos da página em **classes que representam páginas ou componentes da aplicação**, expondo apenas métodos de alto nível que descrevem comportamentos do usuário.

### 🎯 Vantagens do Page Object

- **Separação de responsabilidades**: o teste foca no *comportamento*, a classe Page Object foca na *interface*.
- **Redução de duplicidade**: evita repetição de seletores e ações.
- **Maior legibilidade**: os testes se tornam mais fáceis de ler e entender.
- **Alta manutenção**: alterações na interface exigem mudança apenas na classe Page correspondente.
- **Facilidade de reuso**: páginas/componentes podem ser reutilizados em múltiplos testes.

### 🔧 Exemplo conceitual:

```csharp
// LoginPage.cs
public class LoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver) => _driver = driver;

    public void FillUsername(string username) =>
        _driver.FindElement(By.Id("username")).SendKeys(username);

    public void FillPassword(string password) =>
        _driver.FindElement(By.Id("password")).SendKeys(password);

    public void Submit() =>
        _driver.FindElement(By.Id("login-button")).Click();
}
```

```csharp
// LoginTest.cs
[Test]
public void ShouldLoginWithValidCredentials()
{
    var loginPage = new LoginPage(driver);
    loginPage.FillUsername("admin");
    loginPage.FillPassword("123456");
    loginPage.Submit();

    Assert.IsTrue(driver.PageSource.Contains("Welcome"));
}
```

---

## ⚙️ Tecnologias Utilizadas

- [.NET Core 3.1](https://dotnet.microsoft.com/)
- [Selenium WebDriver](https://www.selenium.dev/)
- [NUnit](https://nunit.org/) ou [xUnit](https://xunit.net/)
- Page Object Pattern
- Aplicações AngularJS e SPA como foco de teste

---

## 🚀 Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/Anselming/Anselme.Webtest.git
   ```
2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```
3. Execute os testes:
   ```bash
   dotnet test
   ```

---

## 🧩 Estrutura esperada

```
AnselmeWebtest/
├── Pages/
│   └── LoginPage.cs
├── Tests/
│   └── LoginTests.cs
├── Drivers/
│   └── WebDriverFactory.cs
└── Anselme.Webtest.sln
```

---

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

> Desenvolvido por [@Anselming](https://github.com/Anselming) com foco em testes robustos, reutilizáveis e de fácil manutenção.
