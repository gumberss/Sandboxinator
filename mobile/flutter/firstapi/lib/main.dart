import 'package:firstapi/screens/transfer_list.dart';
import 'package:flutter/material.dart';

void main() => runApp(App());

class App extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      //theme: ThemeData.dark(),
      theme: ThemeData().copyWith(
          colorScheme: ThemeData().colorScheme.copyWith(
                primary: Colors.green[900],
                secondary: Colors.blue[700],
              ),
          buttonTheme: ThemeData().buttonTheme.copyWith(
              buttonColor: Colors.blue[700],
              textTheme: ButtonTextTheme.primary)),
      home: TransferList(),
    );
  }
}








