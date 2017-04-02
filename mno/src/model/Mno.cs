using Realms;
using System;

namespace mno.src.model
{
    class Mno : RealmObject
    {
        // Id of record in db
        public int Id { get; set; }

        // Date of analysis
        public DateTimeOffset Date { get; set; }

        // MNO analysis result value
        public float Value { get; set; }

        // Resulting warfarin dosage
        public float Dosage { get; set; }

        // Place where analysis was taken
        public string Place { get; set; }
    }
}