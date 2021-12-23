import 'package:flutter/material.dart';
import 'package:secondapi/screens/dashboard.dart';

import 'database/app_database.dart';
import 'models/contect.dart';

void main() async {
  runApp(App());
  final id = await save(Contact(0, 'Gumbers', 100));

  findAll().then((contacts) => debugPrint(contacts.toString()) );
}

class App extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        theme: ThemeData().copyWith(
            colorScheme: ThemeData().colorScheme.copyWith(
                  primary: Colors.green[900],
                )),
        home: Dashboard());
  }
}

