import 'package:flutter/cupertino.dart';
import 'package:path/path.dart';
import 'package:secondapi/models/contect.dart';
import 'package:sqflite/sqflite.dart';

Future<Database> createDatabase() async {
  final dbPath = await getDatabasesPath();

  final path = join(dbPath, 'happy.db');

  return openDatabase(path, onCreate: (db, version) {
    db.execute("CREATE TABLE contacts("
        "id INTEGER PRIMARY KEY, "
        "name TEXT, "
        "account_number INTEGER)");
  }, version: 1);
}

Future<int> save(Contact contact) async {
  final db = await createDatabase();

  final contactMap = Map<String, dynamic>();
  contactMap['name'] = contact.name;
  contactMap['account_number'] = contact.accountNumber;

  final insertedId = await db.insert('contacts', contactMap);

  return insertedId;
}

Future<List<Contact>> findAll() async {
  final db = await createDatabase();

  final data = await db.query('contacts');

  final contacts = data
      .map((Map<String, dynamic> map) =>
          Contact(map['id'], map['name'], map['account_number']))
      .toList();

  return contacts;
}
