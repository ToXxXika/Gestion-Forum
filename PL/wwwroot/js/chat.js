const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.start()
.then(() => {
    connection.invoke("SendMessage", name,message);
    .catch(err=>console.error(err.toString()));
})
.catch(err=>console.error(err.toString()));

connection.on("ReceiveMessage", (user, message) => {
    
});