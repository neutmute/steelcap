# Steelcap: MV6 Tag Helpers for Bootstrap #
A collection of  MVC 6 Tag Helpers for more concise Razor code for describing [Bootstrap](http://getbootstrap.com/) elements

## Form controls ##
Using Steelcap - the following Razor code   

 	<sc-form-group label-text="Name">
        <sc-textbox></sc-textbox>
    </sc-form-group>

    <sc-form-group label-text="Number">
        <sc-numberbox></sc-numberbox>
    </sc-form-group>

    <sc-form-group>
        <sc-form-group-label>
            <h3>A label with HTML</h3>
        </sc-form-group-label>
        <sc-dropdown></sc-dropdown>
    </sc-form-group>

    <sc-widget-box title="My Title">Yay for content!</sc-widget-box>

renders out to the client as

	<div class=" form-group"><label>Name</label><div>
        <input class=" form-control" type="text"></input>
    </div></div>

    <div class=" form-group"><label>Number</label><div>
        <input class=" form-control" type="number"></input>
    </div></div>

    <div class=" form-group"><div>
        <label>
            <h3>A label with HTML</h3>
        </label>
        <select class=" form-control"></select>
    </div></div>

    <div class="widget-box">
		<div class="widget-header">
			<h4 class="widget-title">My Title</h4>
		</div>
		<div class="widget-body">
			<div class="widget-main">Yay for content!</div>
		</div>
	</div>

See [aspnetv5demo](https://github.com/neutmute/aspnetv5demo) for a working demo

Pull requests welcome.
