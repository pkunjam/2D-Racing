var io = require('socket.io')(process.env.PORT || 52300);

//Custom Classes
var Player = require('./Classes/Player.js');

console.log('Server has started');

var players = [];
var sockets = [];

io.on('connection', function(socket){
    console.log('Connection Made!');

    var player = new Player();
    var thisPlayerID = player.id;

    players[thisPlayerID] = player;
    sockets[thisPlayerID] = socket;

    //Tell the client that is our id from the server 
    socket.emit('register', {id: thisPlayerID});
    socket.emit('spawn', player); //Tell myself i have spawned
    socket.broadcast.emit('spawn', player); //Tell other I have spawned

    //Tell myself about everyone else in the game
    for(var playerID in players){
        if(playerID != thisPlayerID){
            socket.emit('spawn', players[playerID]);
        }
    }

    socket.on('disconnect', function(){
        console.log('A player has disconnected');
        delete players[thisPlayerID];
        delete sockets[thisPlayerID];
        socket.broadcast.emit('disconnected'. player);
    });
});