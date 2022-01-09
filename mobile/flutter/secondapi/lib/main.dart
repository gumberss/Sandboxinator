import 'dart:async';

import 'package:flutter/material.dart';
import 'package:secondapi/screens/dashboard.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:firebase_crashlytics/firebase_crashlytics.dart';
import 'package:flutter/foundation.dart' show kDebugMode;

void main() async {

  WidgetsFlutterBinding.ensureInitialized();

  await Firebase.initializeApp();

  if (kDebugMode) {
    await FirebaseCrashlytics.instance
        .setCrashlyticsCollectionEnabled(false);
  } else {
    await FirebaseCrashlytics.instance
        .setCrashlyticsCollectionEnabled(true);
    FirebaseCrashlytics.instance.setUserIdentifier('id do Batman');

    FlutterError.onError = FirebaseCrashlytics.instance.recordFlutterError;
  }
  runZonedGuarded<Future<void>>(() async {
    runApp(App());
  }, FirebaseCrashlytics.instance.recordError);

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

