import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:secondapi/components/progress.dart';
import 'package:secondapi/database/dao/contact_dao.dart';
import 'package:secondapi/models/contact.dart';
import 'package:secondapi/screens/contact_form.dart';
import 'package:secondapi/screens/transaction_form.dart';

class ContactsList extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => ContactsListState();
}

class ContactsListState extends State<ContactsList> {
  final ContactDao _contactDao = ContactDao();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Contacts'),
      ),
      body: FutureBuilder(
          initialData: List<Contact>.empty(growable: true),
          future: _contactDao.findAll(),
          builder:
              (BuildContext context, AsyncSnapshot<List<Contact>> snapshot) {
            switch (snapshot.connectionState) {
              case ConnectionState.none:
                //nothing was done
                break;
              case ConnectionState.waiting:
                return Progress();
                break;
              case ConnectionState.active:
                //stream
                break;
              case ConnectionState.done:
                if (snapshot.hasData) {
                  final List<Contact> contacts = snapshot.data!;
                  return ListView.builder(
                    itemBuilder: (context, index) {
                      final contact = contacts[index];
                      return _ContactItem(contact, () {
                        Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) => TransactionForm(contact)));
                      });
                    },
                    itemCount: contacts.length,
                  );
                }
                break;
            }

            return Text("Treta");
          }),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.of(context)
              .push(MaterialPageRoute(builder: (context) => ContactForm()))
              .then((value) => setState(() {}));
        },
        child: Icon(Icons.add),
      ),
    );
  }
}

class _ContactItem extends StatelessWidget {
  final Contact contact;
  final Function onTap;

  const _ContactItem(this.contact, this.onTap);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: ListTile(
        onTap: () => onTap(),
        title: Text(
          contact.name,
          style: TextStyle(fontSize: 24.0),
        ),
        subtitle: Text(
          contact.accountNumber.toString(),
          style: TextStyle(fontSize: 16.0),
        ),
      ),
    );
  }
}
