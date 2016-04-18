# MainController Class
 

Controlleur regroupant tout les services


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;PigeonsLibrairy.Controller.MainController<br />
**Namespace:**&nbsp;<a href="55678277-c7be-459a-277f-cb45581aba7a">PigeonsLibrairy.Controller</a><br />**Assembly:**&nbsp;PigeonsLibrairy (in PigeonsLibrairy.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public class MainController
```

**VB**<br />
``` VB
Public Class MainController
```

**C++**<br />
``` C++
public ref class MainController
```

**F#**<br />
``` F#
type MainController =  class end
```

The MainController type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="99f5a2a0-c42e-b0a3-c100-e17888bca559">MainController</a></td><td>
Initializes a new instance of the MainController class</td></tr></table>&nbsp;
<a href="#maincontroller-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="f9a50dc0-340f-e444-dff7-ecd7a2755738">AssignationService</a></td><td>
Création du Service pour la table <a href="912fb7ce-cbcd-e571-4846-3144af127f9c">assignation</a> Vérifacation si le dao est null pour conserver le même context</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="0c38ed1b-32df-50e1-77f4-7a51fc2576df">ChatHistoryService</a></td><td>
Création du Service pour la table <a href="f6e3b8f2-5289-041c-bfed-7d1e9141308b">chathistory</a></td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="cc8fc2f8-9969-e55f-be29-c20781075f49">EventService</a></td><td>
Création du Service pour la table <a href="62ad5042-cbd2-c4c9-25f7-10ea54ad8366">event</a> Vérifacation si le dao est null pour conserver le même context</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="ab40ba9e-31ea-1607-bba0-176cd08c21ce">FollowingService</a></td><td>
Création du Service pour la table <a href="31397466-28b4-3b58-1aa9-d8ca73b55c33">following</a> Vérifacation si le dao est null pour conserver le même context</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="50102552-78ba-a69e-6231-af94170d6b0f">GroupService</a></td><td>
Création du Service pour la table <a href="30daa006-0f38-7d8e-5d44-43f8187b044c">group</a> Vérifacation si le dao est null pour conserver le même context</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="5d0401d8-8b3c-553b-de60-ee4e4a75a30c">MessageService</a></td><td>
Création du Service pour la table <a href="891709b8-1ff0-58b3-9aa4-f3f06f37a146">message</a> Vérifacation si le dao est null pour conserver le même context</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="d03cb158-f0e0-2ca9-84ea-8db8b20feba4">PersonService</a></td><td>
Création du Service pour la table <a href="a9ed19a7-a394-5e30-cca4-a3883320ea27">person</a> Vérifacation si le dao est null pour conserver le même context</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="9e021ff5-a6a9-641e-36d2-c4341ffd2a8d">TaskService</a></td><td>
Création du Service pour la table <a href="ed7fd571-3ebd-bb10-4923-b1c31d5523f3">task</a> Vérifacation si le dao est null pour conserver le même context</td></tr></table>&nbsp;
<a href="#maincontroller-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#maincontroller-class">Back to Top</a>

## See Also


#### Reference
<a href="55678277-c7be-459a-277f-cb45581aba7a">PigeonsLibrairy.Controller Namespace</a><br />