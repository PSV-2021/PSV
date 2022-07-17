#!/bin/bash
/usr/local/bin/create-sftp-user user:password
cd home/user
mkdir upload upload/DrugstoreFiles upload/HospitalFiles
chown user upload/DrugstoreFiles upload/HospitalFiles 
../../entrypoint user:password