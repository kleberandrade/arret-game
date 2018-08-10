## Classes

<dl>
<dt><a href="#GameMode">GameMode</a></dt>
<dd></dd>
<dt><a href="#Networking">Networking</a> : <code><a href="#Networking">Networking</a></code></dt>
<dd></dd>
</dl>

<a name="GameMode"></a>

## GameMode
**Kind**: global class  
**Access**: public  

* [GameMode](#GameMode)
    * [new GameMode()](#new_GameMode_new)
    * [~VR](#GameMode..VR) : <code>uint</code>
    * [~MOBILE](#GameMode..MOBILE) : <code>uint</code>

<a name="new_GameMode_new"></a>

### new GameMode()
Esta calsse possui constantes estáticas

<a name="GameMode..VR"></a>

### GameMode~VR : <code>uint</code>
Constante que representa o 

**Kind**: inner property of [<code>GameMode</code>](#GameMode)  
**Access**: public  
<a name="GameMode..MOBILE"></a>

### GameMode~MOBILE : <code>uint</code>
Constante que representa o tipo de gameplay MOBILE.

**Kind**: inner property of [<code>GameMode</code>](#GameMode)  
**Access**: public  
<a name="Networking"></a>

## Networking : [<code>Networking</code>](#Networking)
**Kind**: global class  
**Access**: public  

* [Networking](#Networking) : [<code>Networking</code>](#Networking)
    * [new Networking()](#new_Networking_new)
    * [~PLAYER_COLOR_BLUE](#Networking..PLAYER_COLOR_BLUE) : <code>String</code>
    * [~PLAYER_COLOR_RED](#Networking..PLAYER_COLOR_RED) : <code>String</code>
    * [~PLAYER_COLOR_NONE](#Networking..PLAYER_COLOR_NONE) : <code>String</code>
    * [~_instance](#Networking.._instance) : [<code>Networking</code>](#Networking)
    * [~networked](#Networking..networked) : <code>List</code>
    * [~Instance](#Networking..Instance) : [<code>Networking</code>](#Networking)
    * [~Host](#Networking..Host) : <code>bool</code>
    * [~IO](#Networking..IO) : <code>SocketIOComponent</code>
    * [~PlayerColor](#Networking..PlayerColor) : <code>string</code>
    * [~Awake()](#Networking..Awake)
    * [~TrunVec(vec)](#Networking..TrunVec) ⇒ <code>Vector3</code>
    * [~Connect()](#Networking..Connect) : <code>void</code>
    * [~Register(go)](#Networking..Register) : <code>void</code>
    * [~BroadcastAMessage(methodName, payload)](#Networking..BroadcastAMessage) : <code>void</code>
    * [~MakeMatch(gameMode)](#Networking..MakeMatch) : <code>void</code>
    * [~GameplaySceneLoaded()](#Networking..GameplaySceneLoaded) : <code>void</code>
    * [~Tick()](#Networking..Tick) : <code>void</code>
    * [~PlaceDrone(droneId, position)](#Networking..PlaceDrone) : <code>void</code>
    * [~DestroyDrone(droneId)](#Networking..DestroyDrone) : <code>void</code>
    * [~MoveAlien(newPosition)](#Networking..MoveAlien) : <code>void</code>
    * [~GameOver(_color)](#Networking..GameOver) : <code>void</code>

<a name="new_Networking_new"></a>

### new Networking()
Esta classe é responsável por todo a interface

<a name="Networking..PLAYER_COLOR_BLUE"></a>

### Networking~PLAYER_COLOR_BLUE : <code>String</code>
Constante estática que representa o jogador de cor azul (Drone).

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..PLAYER_COLOR_RED"></a>

### Networking~PLAYER_COLOR_RED : <code>String</code>
Constante estática que representa o jogador de cor vermelha (Drone).

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..PLAYER_COLOR_NONE"></a>

### Networking~PLAYER_COLOR_NONE : <code>String</code>
Constante estática que representa o jogador de que controla o Alien.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking.._instance"></a>

### Networking~_instance : [<code>Networking</code>](#Networking)
Este é o campo estático que 

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..networked"></a>

### Networking~networked : <code>List</code>
Campo público do tipo List<GameObject>.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..Instance"></a>

### Networking~Instance : [<code>Networking</code>](#Networking)
Propriedade pública que dá acesso à instância de Networking do game.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
**Read only**: true  
**Example**  
```js
// Retorna a única instância de Networking.
```
<a name="Networking..Host"></a>

### Networking~Host : <code>bool</code>
Propriedade pública que diz se esta 

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
**Read only**: true  
**Example**  
```js
Networking.Instance.Host;
```
<a name="Networking..IO"></a>

### Networking~IO : <code>SocketIOComponent</code>
Propriedade pública que dá acesso ao

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..PlayerColor"></a>

### Networking~PlayerColor : <code>string</code>
Propriedade pública que dá acesso

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
**Example**  
```js
Networking.Instance.PlayerColor == Networking.PLAYER_COLOR_BLUE;
```
<a name="Networking..Awake"></a>

### Networking~Awake()
No método awake checamos se já existe uma 

**Kind**: inner method of [<code>Networking</code>](#Networking)  
<a name="Networking..TrunVec"></a>

### Networking~TrunVec(vec) ⇒ <code>Vector3</code>
Este método é responsável por 

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Returns**: <code>Vector3</code> - Vector3 com algumas casas decimais truncadas.  

| Param | Type | Description |
| --- | --- | --- |
| vec | <code>Vector3</code> | Vector3 a ser truncado. |

**Example**  
```js
Vector3 vec = new Vector3(1.2335f,1.2335f,1.2335f);
```
<a name="Networking..Connect"></a>

### Networking~Connect() : <code>void</code>
Método responsável por conectar esta instância 

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..Register"></a>

### Networking~Register(go) : <code>void</code>
Inscreve (ou registra) um GameObject

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| go | <code>GameObject</code> | Instância de GameObject a ser inscrito na lista de objetos sincronizados na rede na partida. |

**Example**  
```js
// Utilização
```
<a name="Networking..BroadcastAMessage"></a>

### Networking~BroadcastAMessage(methodName, payload) : <code>void</code>
Este método é uma hack do método nativo da Unity

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  
**Todo**

- [ ] Poderíamos implementar uma melhoria aqui, evitando a utilização do SendMessage a fim de melhorar a performance.


| Param | Type | Description |
| --- | --- | --- |
| methodName | <code>string</code> | String que contém o nome do método a ser invocado no objeto que recebe a mensagem. |
| payload | <code>JSONOBject</code> | Contém os dados recebidos do servidor. É uma instância de JSONObject, classe da implementação de SocketIO Unity que atua como um hash map (encapsulamento de pares chave/valor) para abstrair de forma simplificada objetos JSON. |

**Example**  
```js
// Propaga um evento de OnServerDisconection sem payload
```
<a name="Networking..MakeMatch"></a>

### Networking~MakeMatch(gameMode) : <code>void</code>
Envia uma requisição/solicitação de criação

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| gameMode | <code>uint</code> | Tipo do jogador que está requisitando uma partida. |

**Example**  
```js
// Utilização
```
<a name="Networking..GameplaySceneLoaded"></a>

### Networking~GameplaySceneLoaded() : <code>void</code>
Envia para o servidor uma requisição

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  
**Example**  
```js
// Utilização
```
<a name="Networking..Tick"></a>

### Networking~Tick() : <code>void</code>
Este método funciona como uma espécie de 

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..PlaceDrone"></a>

### Networking~PlaceDrone(droneId, position) : <code>void</code>
Envia para o servidor uma requisição

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| droneId | <code>int</code> | Id do drone que está sendo colocado. |
| position | <code>Vector3</code> | Posição tridimensional onde o Drone está sendo colocado. |

**Example**  
```js
Networking.Instance.PlaceDrone(droneId, towerTransform.position); // Envia o position (truncado no BuildManager) pela rede.
```
<a name="Networking..DestroyDrone"></a>

### Networking~DestroyDrone(droneId) : <code>void</code>
Envia para o servidor uma requisição

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| droneId | <code>int</code> | Id do drone a ser destruído. |

**Example**  
```js
Networking.Instance.PlaceDrone(droneId, towerTransform.position); // Envia o position (truncado no BuildManager) pela rede.
```
<a name="Networking..MoveAlien"></a>

### Networking~MoveAlien(newPosition) : <code>void</code>
Envia para o servidor uma mensagem

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| newPosition | <code>Vector3</code> | Nova posição de alien. |

**Example**  
```js
Networking.Instance.MoveAlien(gameObject.transform.position); // Envia o novo position do gameObject que corresponde ao player "VR" (alien).
```
<a name="Networking..GameOver"></a>

### Networking~GameOver(_color) : <code>void</code>
Envia para o servidor uma mensagem

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| _color | <code>string</code> | representa Indica o vencedor da partida. Três valores possíveis "blue" | "red" | "vr". Apesar do valor "vr" não representar uma cor, precisávamos de um valor para representar o alien (jogador VR). |

**Example**  
```js
Networking.Instance.GameOver("vr");   // Indica o final da partida, vitória para o jogador "VR".
```