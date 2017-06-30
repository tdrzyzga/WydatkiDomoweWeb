#WydatkiDomowe wersja Web

Tomasz Drzyzga
 
# 1) Użyte technologie
Aplikacja bazodanowa stworzona w Visual Studio 2015 .NET wersja 4.6.1 z wykorzystaniem:
- C#, 
- ASP.NET MVC 5, 
- Entity Framework 6.

Front-End:
- biblioteka Bootstrap,
- skrypty jQuery. 

Jako kontener DI zastosowano Ninject. W testach jednostkowych do utworzenia obiektów imitujących użyto bibliotekę Moq. 
Bazę danych utworzono w SQL Server 2014 następnie wykorzystano podejście code first from database.
# 2) Informacje podstawowe
Zadaniem programu jest ewidencja wydatków domowych, tworzenie raportów z wybranych okresów rozliczeniowych itp.
Schemat bazy wygląda następująco:
![Alt text](WydatkiDomoweWeb.Domain/Image/HouseholdExpenses.png)
# 3) Funkcjonalność
Aplikacja umożliwia:
- ewidencja wydatków domowych
- tworzenie raportów za wybrany okres

# 4) Inne
Aplikacja w trakcie tworzenia.... Jej głownym celem jest nauka ASP.NET MVC 5, Entity Framework 6 oraz testów jednostkowych z wykorzystaniem biblioteki wbudowanej w Visual Studio.  

# 5) Postęp prac
Aktualnie (30.06.2017) aplikacja posiada następujące funkcjonalności:
#a) Zakładka "Home" zawiera zestawienie wszystkich zapłaconych rachunków. W zakładce tej można dodawać nowe rachunki, edytować już istniejące oraz usuwać wpisy.

![Alt text](WydatkiDomoweWeb.Domain/Image/Home.png)

![Alt text](WydatkiDomoweWeb.Domain/Image/AddBill.png)

![Alt text](WydatkiDomoweWeb.Domain/Image/EditBill.png)

![Alt text](WydatkiDomoweWeb.Domain/Image/DeleteBill.png)

#b) Zakładka "Rachunki" zawiera zestawienie nazw rachunków wraz z danymi potrzebnymi do ustalenia terminów płatności. W zakładce tej można dodawać nowe nazwy rachunków, edytować już istniejące oraz usuwać wpisy.

![Alt text](WydatkiDomoweWeb.Domain/Image/BillsNames.png)

![Alt text](WydatkiDomoweWeb.Domain/Image/AddBillName.png)

![Alt text](WydatkiDomoweWeb.Domain/Image/EditBillName.png)

![Alt text](WydatkiDomoweWeb.Domain/Image/DeleteBillName.png)

#c) Zakładka "Odbiorcy" zawiera zestawienie odbiorców rachunków wraz z takimi danymi jak nr konta bankowego oraz adres. W zakładce tej można dodawać nowe nazwych odbiorców. Edycja wpisów oraz usuwanie jest w trakcie realizacji.

![Alt text](WydatkiDomoweWeb.Domain/Image/Recipients.png)

![Alt text](WydatkiDomoweWeb.Domain/Image/AddRecipient.png)

