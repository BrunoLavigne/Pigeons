# PersonService.GetBy Method 
 

Appel le DAO pour trouver une person dans la table

**Namespace:**&nbsp;<a href="61ea8cdd-bbb0-4640-7fbb-d4c259f85123">PigeonsLibrairy.Service.Implementation</a><br />**Assembly:**&nbsp;PigeonsLibrairy (in PigeonsLibrairy.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public IEnumerable<person> GetBy(
	string columnName,
	Object value
)
```

**VB**<br />
``` VB
Public Function GetBy ( 
	columnName As String,
	value As Object
) As IEnumerable(Of person)
```

**C++**<br />
``` C++
public:
virtual IEnumerable<person^>^ GetBy(
	String^ columnName, 
	Object^ value
) sealed
```

**F#**<br />
``` F#
abstract GetBy : 
        columnName : string * 
        value : Object -> IEnumerable<person> 
override GetBy : 
        columnName : string * 
        value : Object -> IEnumerable<person> 
```


#### Parameters
&nbsp;<dl><dt>columnName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Le nom de la colonne pour la recherche</dd><dt>value</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />La valeur rechercher</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href="a9ed19a7-a394-5e30-cca4-a3883320ea27">person</a>)<br />Une liste de personne. Une liste vide sinon

#### Implements
<a href="99e72a5f-f617-96e1-79ad-c9fcb156ec79">IService(TEntity).GetBy(String, Object)</a><br />

## See Also


#### Reference
<a href="82db3e61-d364-71e0-875c-84718078065b">PersonService Class</a><br /><a href="61ea8cdd-bbb0-4640-7fbb-d4c259f85123">PigeonsLibrairy.Service.Implementation Namespace</a><br />