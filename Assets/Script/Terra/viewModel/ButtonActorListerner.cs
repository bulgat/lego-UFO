using System.Collections;
using System.Collections.Generic;


public class ButtonActorListerner 
{
	private static string _nameEvent;
	//private static GameObject _imageFiend;
	/*
	public static void SetClickListenerBuilder(GameObject imageFiend,
			ButtonEvent buttonEvent,
			string concreteButton)
	{
		imageFiend.setName(concreteButton);
		imageFiend.setUserObject(buttonEvent);
		imageFiend.addListener(ButtonActorListerner.GetClickListener(buttonEvent.NameEvent));
	}
	public static void SetOverListenerBuilder(Actor imageFiend, ButtonEvent buttonEvent)
	{
		imageFiend.addListener(ButtonActorListerner.GetOverListener(imageFiend, buttonEvent));
	}
	*/
	/*
	public static void SetClickListenerBuilder(Button imageFiend,
			String nameEventButton,
			String concreteButton,
			ButtonEvent buttonEvent)
	{
		imageFiend.setName(concreteButton);

		ButtonEvent userEventModel = new ButtonEvent();
		userEventModel.NameEvent = nameEventButton;
		if (buttonEvent == null)
		{
			imageFiend.setUserObject(userEventModel);
		}
		else
		{

			imageFiend.setUserObject(buttonEvent);
		}
		//imageFiend.setUserObject(userEventModel);
		imageFiend.addListener(ButtonActorListerner.GetClickListener(nameEventButton));
	}
	*/
	/*
	public static ClickListener GetClickListener(String nameEvent)
	{
		_nameEvent = nameEvent;

		return new ClickListener(){
			   float down_x=0;
		float down_y = 0;

		@Override

				public void touchUp(InputEvent event, float x, float y, int pointer, int button) {
					//outputLabel.setText("Press a Button");
	ButtonEvent userEventModel = (ButtonEvent)event.getListenerActor().getUserObject();
	String nameEventButton = userEventModel.NameEvent;
					
					
			    	
					
					
					if (nameEventButton=="Tile") {
						
						int downUp_x = MouseInfo.getPointerInfo().getLocation().x;
	int downUp_y = MouseInfo.getPointerInfo().getLocation().y;



	userEventModel.DownMouseX = down_x-downUp_x;
						userEventModel.DownMouseY = -(down_y-downUp_y);
						
						int r = Math.round(x);


	ControllerButton.EventCall(nameEventButton,

								event.getListenerActor().getName(),userEventModel);
					}
			    }
			    @Override
				public boolean touchDown(InputEvent event, float x, float y, int pointer, int button)
{

	ButtonEvent userEventModel = (ButtonEvent)event.getListenerActor().getUserObject();
	String nameEventButton = userEventModel.NameEvent;

	ControllerButton.EventCall(nameEventButton,
			    			event.getListenerActor().getName(),event.getListenerActor().getUserObject());


	down_x = MouseInfo.getPointerInfo().getLocation().x;
	down_y = MouseInfo.getPointerInfo().getLocation().y;

	return true;
}

@Override
				public void clicked(InputEvent event, float x, float y)
{

}
			    
			    
			};
	}
	public static ClickListener GetOverListener(Actor imageFiend, final ButtonEvent buttonEvent)
{
	_imageFiend = imageFiend;
	return new ClickListener(){
			@Override
			public void enter(InputEvent event, float x, float y, int pointer, Actor fromActor)
	{
		System.out.println("= T ENTER%% victim = ");
		//fromActor.setColor(Color.RED);
		_imageFiend.setColor(Color.RED);
	}
	@Override
			public void exit(InputEvent event, float x, float y, int pointer, Actor toActor)
	{

		//toActor.setColor(Color.BLUE);
		_imageFiend.setColor(Color.WHITE);
	}
	@Override
			public boolean touchDown(InputEvent event, float x, float y, int pointer, int button)
	{
		System.out.println(" s   %%% T O Melee = ");
		ControllerButton.EventCall(ControllerConstant.BuyUnitDialog,
				ControllerConstant.BuyUnitDialog, buttonEvent);
		return true;
	}

};
	}
*/
}
