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
Esta calsse possui constantes estáticasutiliazdas para representar o modo de jogo.Pode ser VR ou MOBILE.Tanto VR quanto MOBILE são executados em dispositivosmobile, porém o VR é executado com dipositivosmontados na cabeça (como GEAR VR ou GEAR BOX).

<a name="GameMode..VR"></a>

### GameMode~VR : <code>uint</code>
Constante que representa o tipo de gameplay "VR".Jogador controla o alien.Este player é considerado o host da partida.

**Kind**: inner property of [<code>GameMode</code>](#GameMode)  
**Access**: public  
<a name="GameMode..MOBILE"></a>

### GameMode~MOBILE : <code>uint</code>
Constante que representa o tipo de gameplay MOBILE.Um dos jogadores controla os drones.

**Kind**: inner property of [<code>GameMode</code>](#GameMode)  
**Access**: public  
<a name="Networking"></a>

## Networking : [<code>Networking</code>](#Networking)
**Kind**: global class  
**Extends**: <code>MonoBehaviour</code>  
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
Esta classe é responsável por todo a interfacede comunição de rede do ARRET. Esta classe é desenvolvida em cima da implementação de SocketIOpara Unity baixada da Unity Asset Store.

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
Este é o campo estático que armazena a referênciada instância de Networking.Padrão Singleton.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..networked"></a>

### Networking~networked : <code>List</code>
Campo público do tipo List<GameObject>.Armazena uma lista de GameObjects que se inscreveram para serem sincronizados em rede na partida. Isto é, terão seus dados trafegados pela rede.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..Instance"></a>

### Networking~Instance : [<code>Networking</code>](#Networking)
Propriedade pública que dá acesso à instância de Networking do game.Padrão Singleton.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
**Read only**: true  
**Example**  
```js
// Retorna a única instância de Networking.Networking.Instance;
```
<a name="Networking..Host"></a>

### Networking~Host : <code>bool</code>
Propriedade pública que diz se esta instância de jogo é o @{host} da partida.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
**Read only**: true  
**Example**  
```js
Networking.Instance.Host;// Retorna true se for o host, false se não for.
```
<a name="Networking..IO"></a>

### Networking~IO : <code>SocketIOComponent</code>
Propriedade pública que dá acesso aocomponente SocletIO da implementaçãoSocketIO Unity.No momento da atribuição deste componentea classe Networking verifica se o client já está conectado ao servidor, se não estiver,conecta-o.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..PlayerColor"></a>

### Networking~PlayerColor : <code>string</code>
Propriedade pública que dá acessoà cor do player desta instância de jogo.

**Kind**: inner property of [<code>Networking</code>](#Networking)  
**Access**: public  
**Example**  
```js
Networking.Instance.PlayerColor == Networking.PLAYER_COLOR_BLUE;// Checa se a cor do jogador da instância atual do jogo é azul.
```
<a name="Networking..Awake"></a>

### Networking~Awake()
No método awake checamos se já existe uma instância de Networking, se já existir, destruimos esta instãncia para que apenas uma esteja em vigor.Padrão singleton.Se não, atribuimos esta instância à referência _instance.

**Kind**: inner method of [<code>Networking</code>](#Networking)  
<a name="Networking..TrunVec"></a>

### Networking~TrunVec(vec) ⇒ <code>Vector3</code>
Este método é responsável por forçar um truncamento das casas após a virgula a fim de evitar imprecisõesno tráfego de valores float pela rede.

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Returns**: <code>Vector3</code> - Vector3 com algumas casas decimais truncadas.  

| Param | Type | Description |
| --- | --- | --- |
| vec | <code>Vector3</code> | Vector3 a ser truncado. |

**Example**  
```js
Vector3 vec = new Vector3(1.2335f,1.2335f,1.2335f);vec = Networking.TruncVec(vec);print(vec); // O retorno será algo próximo à Vector3(1.23f,1.23f,1.23f)
```
<a name="Networking..Connect"></a>

### Networking~Connect() : <code>void</code>
Método responsável por conectar esta instância do game, ao servidor. Este método apenas abre a conexão Socket e solicita o bind do servidor.Este método não adentra salas de jogos nem envia mensagens.Este método declara os principais eventos do SocketIOe gerencia internamente a maioria dos envios e recebimentosde mensagens e disparo dos eventos do jogo.Este método é chamado automaticamente no início da cenaquando o método Awake for executado.

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..Register"></a>

### Networking~Register(go) : <code>void</code>
Inscreve (ou registra) um GameObjectna lista de objetos sincronizados narede na partida.Todos os eventos do jogo que forem recebidospelo Socket são propagados por toda a cenapara todos os objetos inscritos por este método.

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| go | <code>GameObject</code> | Instância de GameObject a ser inscrito na lista de objetos sincronizados na rede na partida. |

**Example**  
```js
// UtilizaçãoNetworking.Instance.Register(gameObject);
```
<a name="Networking..BroadcastAMessage"></a>

### Networking~BroadcastAMessage(methodName, payload) : <code>void</code>
Este método é uma hack do método nativo da UnityBroadcastMessage. A diferença é que BoardcastMessage (nativo)propaga uma mensagem para todos os componentes de um GameObject.Já BroadcastAMessage (hack) propaga para todos os objetos inscritos em Networking.Apesar de sua visibilidade pública, dificilmente este método será utilizado publicamente, pois todo o gerencimanto de propagação demensagens é realizado de forma privada dentro da classe Networking.Pode ser utilizado de publicamente a fim de forçar a propagação de algunseventos, útil para prototipação, teste e mockup.Este método é construído em cima da utilização do método nativo do Unity SendMessage.

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
// Propaga um evento de OnServerDisconection sem payloadNetworking.Instance.BroadcastAMessage("OnServerDisconection", null);// Propaga um evento de OnServerDisconection com payloadNetworking.Instance.BroadcastAMessage("OnJoinRoom", payload);
```
<a name="Networking..MakeMatch"></a>

### Networking~MakeMatch(gameMode) : <code>void</code>
Envia uma requisição/solicitação de criaçãode uma nova partida para o servidor.Recebe o tipo do jogador que está requisitando a partida. Este dado é importante pois o servidor vai distribuindo automaticamente os jogadores conforme seus respectivos tipos e formando partidas completas.

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| gameMode | <code>uint</code> | Tipo do jogador que está requisitando uma partida. |

**Example**  
```js
// UtilizaçãoNetworking.Instance.MakeMatch(GameMode.VR); // Solicita a criação de uma partida e diz para o servidor que o player solicitante joga como VR.
```
<a name="Networking..GameplaySceneLoaded"></a>

### Networking~GameplaySceneLoaded() : <code>void</code>
Envia para o servidor uma requisiçãodizendo que a cena onde se dá o gameplayfoi totalmente carregada e está executando.Serve para iniciar a sincronia da partida com todos os jogadores conectados na mesma.Pode ser chamado no método Start de algum objetoda cena de gameplay.

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  
**Example**  
```js
// UtilizaçãoNetworking.Instance.GameplaySceneLoaded(); // Notifica o server que o gameplay começou para esta instância de jogo.
```
<a name="Networking..Tick"></a>

### Networking~Tick() : <code>void</code>
Este método funciona como uma espécie de heartbeat indicando que cada client está vivo.Este método é chamado a cada 15 segundos por cada client.A cada tick o servidor responde com um evento OnTick recebido pelo client, ondeno payload é recebido o tempo total de partida (autoritativo no server).

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  
<a name="Networking..PlaceDrone"></a>

### Networking~PlaceDrone(droneId, position) : <code>void</code>
Envia para o servidor uma requisiçãodizendo que o jogador atual está colocando um drone.O ideal seria que o servidor gerasse o novo id para o drone e retornasse-o para o client solicitante.Porém para evitar mais uma mensagem, resolvemos que um dos players coloca apenas drones de ID par e o outro apenas drones de ID impar. Assim o server não precisa manter uma lista de qual dronepertence a qual jogador.

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
Envia para o servidor uma requisiçãodizendo que o jogador atual está destruindo um de seus drones.Segue a mesma logica do placeDrone, ondeos ids pares são de um player e os ímpares de oturo.O server então propaga esta mensagem aos demais players para que os clients removam os drones de suas respectivas instâncias de game.

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
Envia para o servidor uma mensagematualizando a posição do alien.Este método deve ser utilizado apenaspelo client cujo jogador joga como gameMode "VR".

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
Envia para o servidor uma mensagemnotificando o servidor de que o game acabou.Esta mensagem deve ser enviada somente pelo jogador considerado o host da partida (player "VR").Pois será o jogador host da partida o responsável por calculará a vitória da partida e o momento do GameOver.

**Kind**: inner method of [<code>Networking</code>](#Networking)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| _color | <code>string</code> | representa Indica o vencedor da partida. Três valores possíveis "blue" | "red" | "vr". Apesar do valor "vr" não representar uma cor, precisávamos de um valor para representar o alien (jogador VR). |

**Example**  
```js
Networking.Instance.GameOver("vr");   // Indica o final da partida, vitória para o jogador "VR".Networking.Instance.GameOver("red");  // Indica o final da partida, vitória para o jogador "vermelho".Networking.Instance.GameOver("blue"); // Indica o final da partida, vitória para o jogador "azul".
```
