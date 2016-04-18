# Service(*TEntity*) Class
 

Service partager par toute les classe de service


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;PigeonsLibrairy.Service.Implementation.Service(TEntity)<br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="#inheritance-hierarchy" />
**Namespace:**&nbsp;<a href="61ea8cdd-bbb0-4640-7fbb-d4c259f85123">PigeonsLibrairy.Service.Implementation</a><br />**Assembly:**&nbsp;PigeonsLibrairy (in PigeonsLibrairy.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public class Service<TEntity>
where TEntity : class

```

**VB**<br />
``` VB
Public Class Service(Of TEntity As Class)
```

**C++**<br />
``` C++
generic<typename TEntity>
where TEntity : ref class
public ref class Service
```

**F#**<br />
``` F#
type Service<'TEntity when 'TEntity : not struct> =  class end
```


#### Type Parameters
&nbsp;<dl><dt>TEntity</dt><dd>Le type de l'Entity</dd></dl>&nbsp;
The Service(TEntity) type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="52b4cd0b-2fc6-dd6b-cfd4-261bd3323e53">Service(TEntity)</a></td><td>
Constructeur</td></tr></table>&nbsp;
<a href="#service(*tentity*)-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="7a507ac8-8650-1449-83f2-d217e85fff45">Delete(Object)</a></td><td>
Appel le DAO afin d'effacer une Entity de la base de données</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="0e03e6ef-007f-5b39-2e7f-7ec74c902675">Delete(TEntity)</a></td><td>
Appel le DAO pour effacer une Entity de la base de données</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="1d3c30ea-c186-6bd6-3fb0-46b405582edc">Get</a></td><td>
Appel le DAO pour trouver une Entity à l'aide d'une requête Linq</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="d4284a6b-c830-40c3-d592-ec3061ffc84c">GetAll</a></td><td>
Appel le DAO afin d'avoir la liste de toute les Entity comprise dans une table</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="f3cbb885-8208-419d-47dd-ff895979d9e6">GetBy</a></td><td>
Appel le DAO pour rechercher une Entity à l'aide d'une valeur dans une colonne donnée</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="0a4dbf1a-23f4-82b0-31e9-2663f7c3f82c">GetByID</a></td><td>
Appel le DAO pour rechercher une Entity par sa clé primaire</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="dbd98bd8-0cb5-9d06-2b1d-963beb39c7ea">Insert</a></td><td>
Appel le DAO pour insérer une Entity dans la base de données</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="443e9f84-4906-03b6-3d6d-5013260f250d">Update</a></td><td>
Appel le DAO pour Updater une Entity</td></tr></table>&nbsp;
<a href="#service(*tentity*)-class">Back to Top</a>

## See Also


#### Reference
<a href="61ea8cdd-bbb0-4640-7fbb-d4c259f85123">PigeonsLibrairy.Service.Implementation Namespace</a><br />

## Inheritance Hierarchy<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;PigeonsLibrairy.Service.Implementation.Service(TEntity)<br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="89f0ccf6-bc92-c564-4548-b9acb5340a71">PigeonsLibrairy.Service.Implementation.AssignationService</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="16cba995-3019-73e1-a6c8-61a29fc66901">PigeonsLibrairy.Service.Implementation.ChatHistoryService</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="e5e88bd9-1f4b-d606-b1c5-f9f94b87bcde">PigeonsLibrairy.Service.Implementation.EventService</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="1d1f94f8-0563-b791-d051-d871f520b638">PigeonsLibrairy.Service.Implementation.FileService</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="56967c12-fbd0-3375-f2d2-e79554e62424">PigeonsLibrairy.Service.Implementation.FollowingService</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="c93708a9-e06b-e1e2-8b57-bc4e00cafbf2">PigeonsLibrairy.Service.Implementation.GroupService</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="00c066ac-586b-bbc2-7b04-9ce203597380">PigeonsLibrairy.Service.Implementation.MessageService</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="82db3e61-d364-71e0-875c-84718078065b">PigeonsLibrairy.Service.Implementation.PersonService</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="3a241cd4-5c5d-f79b-8b04-0e556676a3c9">PigeonsLibrairy.Service.Implementation.TaskService</a><br />