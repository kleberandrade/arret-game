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
Adaptador de rede do jogo, recebe eventos enviadospela classe Networking, quando mensagens específicas para cada evento é recebido pela rede.A classe Networking trata estas mensagens recebidase encaminha o payload para os respectivos eventos.A maioria dos eventos recebe um parâmetro de método chamado payload.Para utilizar este adaptador basta criar um script C# e extender INetworkBehaviour ao invés de MonoBehaviour.Todo e qualquer script que extende INetworkBehaviour vai receber todos os eventos recebidos pela interface de rede.Para capturá-los basta extender o método desejado e utilizar os dados recebidos.Formato de propagação de eventos muito similar ao Photon Unity Networking.

<a name="INetworkBehaviour..OnConnected"></a>

### INetworkBehaviour~OnConnected()
**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
<a name="INetworkBehaviour..OnJoinRoom"></a>

### INetworkBehaviour~OnJoinRoom(payload) ⇒ <code>void</code>
Notifica o client que um novo jogador adentrou a sala.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload://  {//      grid        : string, // Representa o id da GameRoom onde o client atual entrou.//      newuser     : bool,   // Diz para o jogador que entrou na sala se ele é um novo joador ou não.//      totalusers  : number, // Representa o número atualizado de jogadores na GameRoom atual.//      startgame   : bool,   // Representa se a partida deve começar ou não. Utilizado para chamar o carregamento da cena de gamplay após a GameRoom estar completa.//      host        : bool    // Representa se o client atual deve se assumir como host da partida ou não.//  }payload.GetField("newuser").b;     // Obtém o valor do campo "newuser" do tipo {bool} do payload.payload.GetField("totalusers").n;  // Obtém o valor do campo "totalusers" do tipo {int} do payload.
```
<a name="INetworkBehaviour..OnGameAbort"></a>

### INetworkBehaviour~OnGameAbort(payload) ⇒ <code>void</code>
Notifica o client que o jogo atual foi abortado/encerrado por qualquer motivo.O server emite este evento para todos os clients conectados em uma GameRoom quando um dos clientsse desconecta em meio a uma partida.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:// {//     errormsg : 'A player has been disconected from the game' // Mensagem de erro que ocasionou o aborto do game.// }payload.GetField("errormesg").str.ToString(); // Obtém o valor do campo "errormesg" do tipo {string} do payload.
```
<a name="INetworkBehaviour..OnServerDisconection"></a>

### INetworkBehaviour~OnServerDisconection() ⇒ <code>void</code>
Notifica o client de que ele foi desconectado do server.Isto pode acontecer por qualquer motivo, o server caiu, oua conexão de internet do client foi perdida.Nenhum payload é recebido neste evento.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
<a name="INetworkBehaviour..OnServerConnected"></a>

### INetworkBehaviour~OnServerConnected() ⇒ <code>void</code>
Notifica o client que o a conexão com o server foi realizada com sucesso.Nenhum payload é recebido neste evento.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
<a name="INetworkBehaviour..OnGameplayLoaded"></a>

### INetworkBehaviour~OnGameplayLoaded(payload) ⇒ <code>void</code>
Notifica o client que um player finalizou o processo de carregamento da cena de gamplay e pode comecar a jogar.Define tambem se a partida deve comecar ou aguardar outros players carregarem a partida.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:// {//     start : bool// }payload.GetField("start").b; // Obtém o valor do campo "start" do tipo {bool} do payload. Diz se a partida deve ser iniciada ou não.
```
<a name="INetworkBehaviour..OnColorSet"></a>

### INetworkBehaviour~OnColorSet(payload) ⇒ <code>void</code>
Notifica o player atual da cor que ele deverá usar para se representarna partida.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:// {//     color : string // ("blue" | "red")// }payload.GetField("color").str.ToString(); // Obtém o valor do campo "color" do tipo {string} do payload. 
```
<a name="INetworkBehaviour..OnDronePlace"></a>

### INetworkBehaviour~OnDronePlace(payload) ⇒ <code>void</code>
Notifica o client de que um drone foi colocado no mapa.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:// {//     x       : float,    // Posição em x que o drone foi colocado.//     y       : float,    // Posição em y que o drone foi colocado.//     z       : float ,   // Posição em z que o drone foi colocado.//     color   : string,   // Cor do drone que foi colocado.//     droneId : int       // Id do novo drone colocado.// }payload.GetField("x").n;       // Obtém o valor do campo "x" do tipo {float} do payload.payload.GetField("droneId").n; // Obtém o valor do campo "droneId" do tipo {id} do payload.
```
<a name="INetworkBehaviour..OnDroneDestroy"></a>

### INetworkBehaviour~OnDroneDestroy(payload) ⇒ <code>void</code>
Notifica o client de que um drone foi destruido.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:// {//     droneId : int       // Id do novo drone colocado.// }payload.GetField("droneId").n; // Obtém o valor do campo "droneId" do tipo {int} do payload.
```
<a name="INetworkBehaviour..OnMatchStarted"></a>

### INetworkBehaviour~OnMatchStarted() ⇒ <code>void</code>
Notifica o client de que a partida comecou.Nenhum payload é recebido neste evento.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
<a name="INetworkBehaviour..OnTick"></a>

### INetworkBehaviour~OnTick(payload) ⇒ <code>void</code>
Notifica o client do tempo total da partida.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:// {//     m : int, // minutos//     s : int, // segundos//     t : int  // tempo total em segundos// }payload.GetField("t").n; // Obtém o valor do campo "t" do tipo {int} do payload.
```
<a name="INetworkBehaviour..OnAlienMove"></a>

### INetworkBehaviour~OnAlienMove(payload) ⇒ <code>void</code>
Notifica o client da nova posição do alien.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:// {//     x : float,//     y : float,//     z : float// }payload.GetField("x").n; // Obtém o valor do campo "x" do tipo {float} do payload.payload.GetField("y").n; // Obtém o valor do campo "y" do tipo {float} do payload.payload.GetField("z").n; // Obtém o valor do campo "z" do tipo {float} do payload.
```
<a name="INetworkBehaviour..OnGameOver"></a>

### INetworkBehaviour~OnGameOver(payload) ⇒ <code>void</code>
Notifica o client de que o game acabou e traz a representação em string do GameMode do player que venceu a partida.O payload é recebido em formato JSONObject. É uma classepara serialização de objetos JSON baseado em Dictionary. Ou seja, o conteúdo é armazenado em formato chave/valor.JSONObject parseia automaticamente os tipos de dados para o mais adequado.Valores numéricos recebidos são automaticamente convertidospara tipo numérico e devem ser acessados via GetField.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  

| Param | Type | Description |
| --- | --- | --- |
| payload | <code>JSONObject</code> | Conteúdo da mensagem recebido pela rede em formato JSON. |

**Example**  
```js
// Layout do payload:// {//     winner : "blue" | "red" | "vr"// }payload.GetField("winner").str.ToString(); // Obtém o valor do campo "winner" do tipo {string} do payload.
```
<a name="INetworkBehaviour..OnVictory"></a>

### INetworkBehaviour~OnVictory() ⇒ <code>void</code>
Notifica o client de que ganhou a partida.Nenhum payload é recebido neste evento.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
<a name="INetworkBehaviour..OnDefeat"></a>

### INetworkBehaviour~OnDefeat() ⇒ <code>void</code>
Notifica o client de que perdeu a partida.Nenhum payload é recebido neste evento.

**Kind**: inner method of [<code>INetworkBehaviour</code>](#INetworkBehaviour)  
**Access**: public  
