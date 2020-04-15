#MAP

#create
	colors = %{primary: "red", secondary: "blue"}
	%{primary: primary_color} = colors
	primary_color

#'update'
	colors = %{primary: "red", secondary: "blue"}
	new_colors = Map.put(colors, :primary, "green")
	new_colors_2 = %{ colors | primary: 'black' }
 

#LIST
	list = [{:primary, "red" }, {:secondary, "green"}]
	list_other_way = [primary: "red", secondary: "green"]
