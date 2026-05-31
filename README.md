# Laboration 2 – Grupp 8

# Brädhörnan

Brädhörnan är en WPF-applikation för hantering av en brädspelsförening. Systemet gör det möjligt att administrera medlemmar, spel och event samt registrera deltagare till olika aktiviteter.

## Gruppmedlemmar

* Rasmus Serrestam
* Zanist Delsoz Kamal

## Funktionalitet

Applikationen stödjer följande funktioner:

### Medlemmar

* Visa medlemmar
* Registrera nya medlemmar
* Redigera befintliga medlemmar
* Ta bort medlemmar

### Spel

* Visa spel
* Registrera nya spel
* Redigera befintliga spel
* Ta bort spel

### Event

* Skapa event
* Redigera event
* Ta bort event
* Visa eventdetaljer
* Registrera deltagare till event
* Avregistrera deltagare från event

### Övrigt

* Persistent lagring med Entity Framework Core
* Demonstrationsdata (seed-data)
* Databindning enligt MVVM
* LINQ för filtrering, sortering och datahantering
* Validering och felhantering

## Tekniker

Projektet är utvecklat med:

* C#
* .NET
* WPF
* MVVM
* CommunityToolkit.Mvvm
* Entity Framework Core
* SQL Server LocalDB

## Projektstruktur

### Models

Innehåller domänklasser såsom:

* Member
* Game
* Event

### Data

Innehåller:

* ApplicationDbContext
* Repository-klasser
* SeedData

### Services

Ansvarar för applikationslogik och kommunikation med dataåtkomstlagret.

### ViewModels

Ansvarar för presentationslogik och databindning enligt MVVM.

### Views

WPF-vyer och dialogfönster.

## Databas

Projektet använder Entity Framework Core tillsammans med SQL Server LocalDB.

Databasen skapas automatiskt vid första uppstarten och fylls med demonstrationsdata genom SeedData.

Demonstrationsdatan innehåller:

* Medlemmar
* Spel
* Event
* Registrerade deltagare

## Krav för att köra projektet

### Programvara

* Visual Studio 2022 eller senare
* .NET 8.0 SDK
* SQL Server LocalDB

### Starta projektet

1. Klona eller ladda ner repositoryt.
2. Öppna lösningen i Visual Studio.
3. Säkerställ att nödvändiga NuGet-paket återställs.
4. Bygg lösningen.
5. Starta projektet med F5 eller Ctrl+F5.

## Arkitektur

Projektet följer MVVM-principen:

* Views ansvarar för presentation.
* ViewModels ansvarar för användarinteraktion och tillstånd.
* Services ansvarar för verksamhetslogik.
* Data-lagret ansvarar för databasåtkomst via Entity Framework.

Detta ger en tydlig separation mellan presentation, applikationslogik och dataåtkomst.

## Centralt arbetsflöde

Registrera deltagare till event:

1. Användaren väljer ett event.
2. Användaren öppnar dialogen för deltagarregistrering.
3. Endast medlemmar som inte redan är registrerade visas.
4. Användaren väljer medlem.
5. Registreringen sparas i databasen.
6. Eventets deltagarlista uppdateras.
