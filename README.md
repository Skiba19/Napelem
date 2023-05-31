# Napelem-API

A README egy C# nyelven írt WPF alkalmazás dokumentációját tartalmazza. Az alkalmazás egy napelemes projektek kezelésére szolgáló szoftver, melynek backend része a következő részekből áll:

AdminController.cs

A kód a Napelem_API.Controllers névtérben található AdminController osztályt tartalmazza. Az osztály az ApiControllerBase osztályból származik, és a [Route("api/[controller]")] és [ApiController] attribútumokkal van ellátva.

A főbb részek és metódusok a következők:

- [HttpPost]: Ez az attribútum jelzi, hogy a CreateEdit metódus az HTTP POST kéréseket fogadja.

- CreateEdit(Employee employee): Ez a metódus a POST kérések fogadására szolgál. Egy Employee objektumot vár paraméterként, ami a munkavállalót reprezentálja. A metódus először ellenőrzi, hogy a felhasználó már létezik-e a rendszerben a IsUserExists metódus segítségével. Ha a felhasználó nem létezik, hozzáadja az adatbázishoz az Employees táblához, majd menti a változásokat (context.SaveChanges()). Végül visszatér egy JSON válasszal az employee objektummal, ha a művelet sikeres volt, vagy egy Conflict (HTTP 409) válasszal, ha a felhasználó már létezik.

- IsUserExists(Employee emp): Ez a privát segédmetódus ellenőrzi, hogy a paraméterként kapott emp munkavállaló már szerepel-e az adatbázisban. Ehhez létrehoz egy NapelemContext példányt, és végigmegy az Employees táblában található munkavállalókon. Ha talál olyan munkavállalót, amelynek a neve megegyezik a paraméterként kapott munkavállaló nevével, akkor igaz értéket ad vissza, különben hamis értéket ad vissza.

- Ez a kontroller a felhasználók létrehozását és módosítását kezeli. Amikor egy POST kérés érkezik a api/Admin végponton, a CreateEdit metódus fogadja és ellenőrzi, hogy a felhasználó már létezik-e az adatbázisban. Ha nem, akkor hozzáadja a felhasználót az adatbázishoz. Ha a felhasználó már létezik, akkor Conflict választ küld vissza.

ComponentController.cs
A kód a Napelem_API.Controllers névtérben található ComponentController osztályt tartalmazza. Az osztály az ApiControllerBase osztályból származik, és a [Route("api/[controller]")] és [ApiController] attribútumokkal van ellátva

- [HttpPost("AddComponent")]: Ez az attribútum jelzi, hogy az AddComponent metódus az HTTP POST kéréseket fogadja a "api/Component/AddComponent" végponton. A metódus egy Component objektumot vár paraméterként, ami az összetevőt reprezentálja. A metódus először ellenőrzi, hogy az összetevő már létezik-e a rendszerben a IsComponentExistsByName metódus segítségével. Ha az összetevő nem létezik, hozzáadja az adatbázishoz a Components táblához, majd menti a változásokat (context.SaveChanges()). Végül visszatér egy JSON válasszal az component objektummal, ha a művelet sikeres volt, vagy egy Conflict (HTTP 409) válasszal, ha az összetevő már létezik.

- IsComponentExistsByName(Component comp): Ez a privát segédmetódus ellenőrzi, hogy a paraméterként kapott comp összetevő már szerepel-e az adatbázisban a neve alapján. Ehhez létrehoz egy NapelemContext példányt, és végigmegy a Components táblában található összetevőkön. Ha talál olyan összetevőt, amelynek a neve megegyezik a paraméterként kapott összetevő nevével, akkor igaz értéket ad vissza, különben hamis értéket ad vissza.

- További metódusok: Az osztály többi metódusa hasonló módon működik, és különböző műveleteket végez az összetevőkkel. A metódusokhoz használt attribútumok ([HttpPost] és [HttpGet]) jelzik az adott metódusokhoz tartozó HTTP kérést és az URL útvonalakat.

- Ez a kontroller az összetevőkkel kapcsolatos műveleteket végzi. Például az AddComponent metódus az összetevők hozzáadását kezeli, a ChangePrice metódus az ár módosítását, a ChangeMaxQuantity metódus a maximális mennyiség módosítását, a SendComponent metódus az összetevők lekérdezését, míg a ChangeQuantity metódus a mennyiség módosítását végzi.

EmployeeController.cs
- public EmployeeController(): Ez a konstruktor a EmployeeController osztály inicializálására szolgál.

- [HttpGet]: Ez az attribútum jelzi, hogy a Get metódus az HTTP GET kéréseket fogadja a "api/Employee" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza a talált alkalmazottat, vagy null értéket, ha nem található olyan alkalmazott, amelynek a felhasználóneve és jelszava megegyezik a paraméterben megadottakkal. A metódus végigiterál az adatbázisban található alkalmazottakon, és ellenőrzi, hogy van-e olyan alkalmazott, amelynek a felhasználóneve és jelszava megegyezik a paraméterben megadottakkal. Ha talál ilyen alkalmazottat, akkor visszatér vele JSON formátumban a válasszal, különben pedig null értékkel tér vissza.

- Ez a kontroller az alkalmazottakkal kapcsolatos műveletet végzi. Például a Get metódus az alkalmazottak bejelentkezését kezeli, ellenőrzi a felhasználónevet és jelszót, és visszaadja az alkalmazottat, ha a bejelentkezés sikeres.

LogController.cs
- [HttpPost("AddLog")]: Ez az attribútum jelzi, hogy a AddLog metódus az HTTP POST kéréseket fogadja a "api/Log/AddLog" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza a hozzáadott naplóbejegyzést. A metódus egy új Log objektumot hoz létre a paraméterben kapott l objektum alapján, majd hozzáadja ezt az objektumot az adatbázishoz (NapelemContext) és elmenti a változásokat.

- Ez a kontroller a naplóbejegyzésekkel kapcsolatos műveleteket végzi. A AddLog metódus hozzáad egy új naplóbejegyzést az adatbázishoz a paraméterben megadott adatokkal.

ProjectController.cs
- [HttpPost("AddProject")]: Ez az attribútum jelzi, hogy a AddProject metódus az HTTP POST kéréseket fogadja a "api/Project/AddProject" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza a hozzáadott projektet. A metódus egy új Project objektumot hoz létre a paraméterben kapott project objektum alapján, beállítja a projekt árát nullára, majd hozzáadja ezt az objektumot az adatbázishoz (NapelemContext) és elmenti a változásokat.

- [HttpGet("ListProjects")]: Ez az attribútum jelzi, hogy a ListProjects metódus az HTTP GET kéréseket fogadja a "api/Project/ListProjects" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza az összes projektet az adatbázisból.

- [HttpPost("SetTimeAndWage")]: Ez az attribútum jelzi, hogy a SetTimeAndWage metódus az HTTP POST kéréseket fogadja a "api/Project/SetTimeAndWage" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza a beállított időt és bért. A metódus az adatbázisban megkeresi a megfelelő projektet (projectID alapján) és beállítja az estimated_Time és wage tulajdonságokat a paraméterben kapott értékek alapján.

- [HttpPost("ChangeStatus")]: Ez az attribútum jelzi, hogy a ProjectClosure metódus az HTTP POST kéréseket fogadja a "api/Project/ChangeStatus" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza a megváltozott státuszt. A metódus az adatbázisban megkeresi a megfelelő projektet (projectID alapján) és beállítja a status tulajdonságot a paraméterben kapott érték alapján.

- [HttpPost("ChangePrice")]: Ez az attribútum jelzi, hogy a ChangePrice metódus az HTTP POST kéréseket fogadja a "api/Project/ChangePrice" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza a megváltozott projektt árat. A metódus az adatbázisban megkeresi a megfelelő projektet (projectID alapján) és beállítja a project_price tulajdonságot a paraméterben kapott érték alapján.

- [HttpGet("GetProjectById")]: Ez az attribútum jelzi, hogy a GetProjectById metódus az HTTP GET kéréseket fogadja a "api/Project/GetProjectById" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza a megadott projectID-vel rendelkező projektet. A metódus először megnézi, hogy a projekt státusza "Scheduled"-e, és csak akkor adja vissza a projektet, ha ez teljesül.

- [HttpGet]: Ez az attribútum jelzi, hogy a ProjectByID metódus az HTTP GET kéréseket fogadja a "api/Project" végponton. A metódus egy JsonResult objektumot ad vissza, ami JSON formátumban tartalmazza a megadott projectID-vel rendelkező projektet.

- StatusCheck(int proId): Ez egy privát segédmetódus, amely ellenőrzi, hogy a megadott proId-vel rendelkező projekt státusza "Scheduled"-e vagy sem. A metódus végigmegy az adatbázisban lévő projekteken, és ha talál egyezést a projekt azonosító és a státusz alapján, akkor true értékkel tér vissza. Ellenkező esetben false értékkel tér vissza.

ReservationController.cs
- AddReservation - POST kérésre válaszol. Hozzáad egy foglalást a megadott projekt-komponens párhoz a Reservation osztály alapján. A foglalás részleteit a ProjectComponent objektumból veszi át, amely tartalmazza a projektet, a komponenst és a mennyiséget. A foglalást hozzáadja az adatbázishoz (NapelemContext) és elmenti a változtatásokat. A válasz egy JSON objektum az eredménnyel.

- ListReservation - GET kérésre válaszol. Lekéri az összes foglalást az adatbázisból (NapelemContext) és visszatér egy JSON objektummal, amely tartalmazza a foglalásokat.

- ChangeReservation_quantity - POST kérésre válaszol. Megváltoztatja a megadott foglalás mennyiségét a Reservation osztály alapján. A módosítást végzi az adatbázisban (NapelemContext) és elmenti a változtatásokat. A válasz egy JSON objektum az eredménnyel.

StorageController.cs
- Az alábbi kód egy ComponentStorage és egy ReservationsAndProjectId osztályt tartalmaz, valamint a StorageController kontrollert.

- A ComponentStorage osztály tárolja a Component és Storage objektumokat. A ReservationsAndProjectId osztály pedig egy listát (resers) és egy projekt azonosítót (projectId) tartalmaz.

- A StorageController egy ASP.NET Core kontroller, amely az árukészletekkel kapcsolatos műveleteket kezeli. Az alábbi műveleteket tartalmazza:

- GetStorage - GET kérésre válaszol. Visszaadja a megadott komponens azonosítójú árukészletet.

- AddComponentToStorage - POST kérésre válaszol. Hozzáad egy komponenst az árukészlethez.

- IsComponentFit - Ellenőrzi, hogy a komponens illeszkedik-e az árukészletbe.

- IsQuantityGreaterThenMax - Ellenőrzi, hogy a komponens mennyisége meghaladja-e a maximális mennyiséget az árukészletben.

- IsStorageExist - Ellenőrzi, hogy az adott árukészlet már létezik-e.

- ListStorages - GET kérésre válaszol. Visszaadja az összes árukészletet.

- IsComponentExistsByID - Ellenőrzi, hogy a komponens azonosítójával rendelkező árukészlet létezik-e.

- ChangeCurrent_quantity - POST kérésre válaszol. Módosítja az árukészlet aktuális mennyiségét.

- IsReservationProjectIdEqualProjectId - Ellenőrzi, hogy a foglalás projekt azonosítója megegyezik-e a projekt azonosítóval.

- IsReservationComponentIdEqualComponentId - Ellenőrzi, hogy a foglalás komponens azonosítója megegyezik-e a komponens azonosítóval.

- ChangeStorage - POST kérésre válaszol. Módosítja az árukészletet és a foglalásokat a megadott projekt azonosítóval és a hozzárendelt foglalásokkal.

- Ezek a műveletek lehetővé teszik az árukészlet kezelését, komponensek hozzáadását, mennyiségek módosítását, valamint az árukészlet és a foglalások közötti kapcsolat kezelését.






