<a name="INetworkBehaviour"></a>

## INetworkBehaviour : <code>InetworkBehaviour</code>
**Kind**: global class  
**Access**: public  

* [INetworkBehaviour](#INetworkBehaviour) : <code>InetworkBehaviour</code>
    * [new INetworkBehaviour()](#new_INetworkBehaviour_new)
    * [~OnConnected()](#INetworkBehaviour..OnConnected)
    * [~OnJoinRoom(payload)](#INetworkBehaviour..OnJoinRoom) ⇒ <code>void</code>
    * [~OnGameAbort(payload)](#INetworkBehaviour..OnGameAbort) ⇒ <code>void</code>
    * [~OnServerDisconection()](#INetworkBehaviour..OnServerDisconection) ⇒ <code>void</code>
    * [~OnServerConnected()](#INetworkBehaviour..OnServerConnected) ⇒ <code>void</code>
    * [~OnGameplayLoaded(payload)](#INetworkBehaviour..OnGameplayLoaded) ⇒ <code>void</code>
    * [~OnColorSet(payload)](#INetworkBehaviour..OnColorSet) ⇒ <code>void</code>
    * [~OnDronePlace(payload)](#INetworkBehaviour..OnDronePlace) ⇒ <code>void</code>
    * [~OnDroneDestroy(payload)](#INetworkBehaviour..OnDroneDestroy) ⇒ <code>void</code>
    * [~OnMatchStarted()](#INetworkBehaviour..OnMatchStarted) ⇒ <code>void</code>
    * [~OnTick(payload)](#INetworkBehaviour..OnTick) ⇒ <code>void</code>
    * [~OnAlienMove(payload)](#INetworkBehaviour..OnAlienMove) ⇒ <code>void</code>
    * [~OnGameOver(payload)](#INetworkBehaviour..OnGameOver) ⇒ <code>void</code>
    * [~OnVictory()](#INetworkBehaviour..OnVictory) ⇒ <code>void</code>
    * [~OnDefeat()](#INetworkBehaviour..OnDefeat) ⇒ <code>void</code>

<a name="new_INetworkBehaviour_new"></a>

### new INetworkBehaviour()
Adaptador de rede do jogo, recebe eventos enviados

<a name="INetworkBehaviour..OnConnected"></a>

### INetworkBehaviour~OnConnected()
**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
<a name="INetworkBehaviour..OnJoinRoom"></a>

### INetworkBehaviour~OnJoinRoom(payload) ⇒ <code>void</code>
Notifica o client que um novo jogador adentrou a sala.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnGameAbort"></a>

### INetworkBehaviour~OnGameAbort(payload) ⇒ <code>void</code>
Notifica o client que o jogo atual foi 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnServerDisconection"></a>

### INetworkBehaviour~OnServerDisconection() ⇒ <code>void</code>
Notifica o client de que ele foi desconectado do server.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
<a name="INetworkBehaviour..OnServerConnected"></a>

### INetworkBehaviour~OnServerConnected() ⇒ <code>void</code>
Notifica o client que o a conexão com 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
<a name="INetworkBehaviour..OnGameplayLoaded"></a>

### INetworkBehaviour~OnGameplayLoaded(payload) ⇒ <code>void</code>
Notifica o client que um player finalizou o processo de 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnColorSet"></a>

### INetworkBehaviour~OnColorSet(payload) ⇒ <code>void</code>
Notifica o player atual da cor que 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnDronePlace"></a>

### INetworkBehaviour~OnDronePlace(payload) ⇒ <code>void</code>
Notifica o client de que um 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnDroneDestroy"></a>

### INetworkBehaviour~OnDroneDestroy(payload) ⇒ <code>void</code>
Notifica o client de que 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnMatchStarted"></a>

### INetworkBehaviour~OnMatchStarted() ⇒ <code>void</code>
Notifica o client 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
<a name="INetworkBehaviour..OnTick"></a>

### INetworkBehaviour~OnTick(payload) ⇒ <code>void</code>
Notifica o client do 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnAlienMove"></a>

### INetworkBehaviour~OnAlienMove(payload) ⇒ <code>void</code>
Notifica o client da 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnGameOver"></a>

### INetworkBehaviour~OnGameOver(payload) ⇒ <code>void</code>
Notifica o client de que o game 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:
```
<a name="INetworkBehaviour..OnVictory"></a>

### INetworkBehaviour~OnVictory() ⇒ <code>void</code>
Notifica o client de 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
<a name="INetworkBehaviour..OnDefeat"></a>

### INetworkBehaviour~OnDefeat() ⇒ <code>void</code>
Notifica o client de 

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  