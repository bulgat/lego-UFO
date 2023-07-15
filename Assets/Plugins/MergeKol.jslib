mergeInto(LibraryManager.library, {

	Hello: function() {
        //window.alert("Hello, world!");
		console.log("0001 Hello ");
		console.log("0002 Hel window.ysdk =",window.ysdk);
		console.log("0003 Hel window.myGameInstance =",window.myGameInstance);
    },
	LaunchTest: function() {
        //window.alert("Hello, world!");
		console.log("0001 Hello ");
		console.log("0002 He window.ysdk =",window.ysdk);
		console.log("0003 He window.myGameInstance =",window.myGameInstance);
		window.myGameInstance.SendMessage('MergeTestJs','SetName',player.getName());
		console.log("0004 -------------------MergeTestJs=" );
		//Auth();
		//SetAuth("non7868678");
    },
	GetDataPlayer: function() {
		
		window.alert("0 player = ",player);
		console.log("1 player = ",player);
		console.log("2 player name= ",player.getName());
		console.log("3 player photo = ",player.getPhoto("medium"));
		console.log("4 player myGameInstance = ",myGameInstance);
		
		myGameInstance.SendMessage('MergeTestJs','SetName',player.getName());
		console.log("5 player myGameInstance = ",myGameInstance);
		myGameInstance.SendMessage('MergeTestJs','SetPhoto',player.getPhoto("medium"));
		
        console.log("6 player myGameInstance = ",myGameInstance);
		//myGameInstance.SendMessage('MergeTestJs','Auth'));
		console.log("7 player myGameInstance = ",myGameInstance);
    },
	 InitPurchases: function() {
		initPayments();
	  },

	  Purchase: function(id) {
		buy(id);
	  },

	  AuthenticateUser: function() {
		var kkk =auth();
		console.log("0010 kkk ",kkk);
	  },

	  GetUserData: function() {
		//var stop = getUserData();
		console.log("0011   GetUserData stop ");
	  },

	  ShowFullscreenAd: function () {
		showFullscrenAd();
	  },

	  ShowRewardedAd: function(placement) {
		showRewardedAd(placement);
		return placement;
	  },

	  OpenWindow: function(link){
		var url = Pointer_stringify(link);
		  document.onmouseup = function()
		  {
			window.open(url);
			document.onmouseup = null;
		  }
	  }

});

