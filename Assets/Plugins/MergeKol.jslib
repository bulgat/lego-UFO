mergeInto(LibraryManager.library, {

	Hello: function() {
        //window.alert("Hello, world!");
		console.log("Hello,  kol");
    },
	GetDataPlayer: function() {
        window.alert("player = ",player);
		console.log("player = ",player);
		console.log("player = ",player.getName());
		console.log("player = ",player.getPhoto("medium"));
    },
 

});

