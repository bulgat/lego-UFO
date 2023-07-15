mergeInto(LibraryManager.library, {

	Hello: function() {
        //window.alert("Hello, world!");
		console.log("0001 Hello,  kol");
		console.log("0002 Hell =",window.ysdk);
		console.log("0003 Hell =",window.myGameInstance);
    },
	LaunchTest: function() {
        //window.alert("Hello, world!");
		console.log("0001 Hello,  kol");
		console.log("0002 Hell =",window.ysdk);
		console.log("0003 Hell =",window.myGameInstance);
    },
	GetDataPlayer: function() {
		
		window.alert("player = ",player);
		console.log("player = ",player);
		console.log("player = ",player.getName());
		console.log("player = ",player.getPhoto("medium"));
		
		MyGameInstance.SendMessage('MergeTestJs','SetName',player.getName());
		MyGameInstance.SendMessage('MergeTestJs','SetPhoto',player.getPhoto("medium"));
		
        
    },
 

});

