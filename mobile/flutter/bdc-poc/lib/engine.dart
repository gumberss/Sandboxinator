import 'dart:convert';

import 'package:flutter/material.dart';

class Engine {
  List<Widget> appBarActions(List<Map<String, dynamic>> actions) {
    return [];
  }

  Scaffold buildScreen() {
    String screenDetails = "{  \"body\": {    \"type\": \"column\",    \"components\": [      {        \"type\": \"button\",        \"text\": \"lala\",        \"actionType\": \"newScreen\",        \"actionParams\": {          \"lala\": \"po\"        }      }    ]  }}";

    var screenMap = jsonDecode(screenDetails);
    return Scaffold(
      appBar: AppBar(
//        actions: appBarActions(screenMap["appBarActions"]),
          ),
      body: StatelessBuilder(screenMap["body"]),


    );
  }
}

void requestScreen(Map<String, dynamic> a) {
  debugPrint("Requesting screen");
}

void Function()? buildAction(Map<String, dynamic> component) {
  return component["actionType"] == "newScreen"
      ? () => requestScreen(component["actionParams"])
      : () => debugPrint("que");
}

Widget buildComponent(dynamic component) {
  return component["type"] == "button"
      ? OutlinedButton(
          onPressed: buildAction(component), child: Text(component["text"]))
      : Column();
}

class StatelessBuilder extends StatelessWidget {
  dynamic body;

  StatelessBuilder(this.body);

  @override
  Widget build(BuildContext context) {
    var alignment = body["type"] == "column"
        ? Column(
            children: (body["components"] as List)
                .map(buildComponent)
                .toList(),
          )
        : Row();

    return alignment;
  }
}
