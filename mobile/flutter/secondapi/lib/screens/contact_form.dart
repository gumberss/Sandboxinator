import 'package:flutter/material.dart';
import 'package:secondapi/database/dao/contact_dao.dart';
import 'package:secondapi/models/contact.dart';

class ContactForm extends StatefulWidget {
  @override
  State<ContactForm> createState() => _ContactFormState();
}

class _ContactFormState extends State<ContactForm> {
  final TextEditingController _nameController = TextEditingController();

  final TextEditingController _accountNumberController =
      TextEditingController();

  final ContactDao _contactDao = ContactDao();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: Text('Create a new Contact')),
        body: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            children: [
              TextField(
                controller: _nameController,
                decoration: InputDecoration(labelText: 'Full Name'),
                style: TextStyle(fontSize: 24.0),
              ),
              Padding(
                padding: const EdgeInsets.only(top: 8.0),
                child: TextField(
                  controller: _accountNumberController,
                  decoration: InputDecoration(labelText: 'Account Number'),
                  style: TextStyle(fontSize: 24.0),
                  keyboardType: TextInputType.number,
                ),
              ),
              Padding(
                padding: const EdgeInsets.only(top: 24.0),
                child: SizedBox(
                  width: double.maxFinite,
                  child: ElevatedButton(
                      onPressed: () async {
                        final String? name = _nameController.text;
                        final int? accountNumber =
                            int.tryParse(_accountNumberController.text);
                        if (name != null && accountNumber != null) {
                          {
                            final contact = Contact(1, name, accountNumber);
                            await _contactDao.save(contact);
                            Navigator.pop(context);
                          }
                        }
                      },
                      child: Text('Create')),
                ),
              )
            ],
          ),
        ));
  }
}
