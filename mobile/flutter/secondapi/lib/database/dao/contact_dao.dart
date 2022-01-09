
import 'package:secondapi/models/contact.dart';

import '../app_database.dart';

class ContactDao {

  static const String tableSql = "CREATE TABLE contacts("
      "id INTEGER PRIMARY KEY, "
      "name TEXT, "
      "account_number INTEGER)";

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
}