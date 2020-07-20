using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    [Serializable]
    public class Person : Party
    {
        #region persistent

        public virtual HierarchicalCategory BloodGroup { get; set; }
        public virtual Country CitizenOf { get; set; } //Nationality 
        
        private PersonName currentName;
        public virtual PersonName CurrentName
        {
            get { return this.currentName; }
            set
            {
                this.currentName = value;
            }
        }
        
        public virtual string EmailAddress { get; set; }
        public virtual HierarchicalCategory Gender { get; set; }
        public virtual string BirthCertificate { get; set; }
        public virtual string DeathCertificate { get; set; }
        public virtual string HomePhoneNo { get; set; }
        public virtual string MobilePhoneNo { get; set; }
        public virtual HierarchicalCategory Occupation { get; set; }
        public virtual HierarchicalCategory Race { get; set; }
        public virtual HierarchicalCategory Religion { get; set; } 

        private IList<InterPersonRelation> personRelationships;
        public virtual IList<InterPersonRelation> PersonRelationships
        {
            get
            {
                if (null == this.personRelationships)
                    this.personRelationships = new List<InterPersonRelation>();
                return this.personRelationships;
            }

            set
            {
                this.personRelationships = value;
            }
        }
        private IList<AcademicEventParticipation> academicEventParticipations;
        public virtual IList<AcademicEventParticipation> AcademicEventParticipations
        {
            get
            {
                if (null == this.academicEventParticipations)
                    this.academicEventParticipations = new List<AcademicEventParticipation>();
                return this.academicEventParticipations;
            }

            set
            {
                this.academicEventParticipations = value;
            }
        }

        private IList<Education> educations;
        public virtual IList<Education> Educations
        {
            get
            {
                if (null == this.educations)
                    this.educations = new List<Education>();
                return this.educations;
            }

            set
            {
                this.educations = value;
            }
        }

        private IList<Experience> experiences;
        public virtual IList<Experience> Experiences
        {
            get
            {
                if (null == this.experiences)
                    this.experiences = new List<Experience>();
                return this.experiences;
            }

            set
            {
                this.experiences = value;
            }
        }

        private IList<RoyalDecoration> royalDecorations;
        public virtual IList<RoyalDecoration> RoyalDecorations
        {
            get
            {
                if (null == this.royalDecorations)
                    this.royalDecorations = new List<RoyalDecoration>();
                return this.royalDecorations;
            }

            set
            {
                this.royalDecorations = value;
            }
        }

        private IList<AcademicAchievement> academicAchievements;
        public virtual IList<AcademicAchievement> AcademicAchievements
        {
            get
            {
                if (null == this.academicAchievements)
                    this.academicAchievements = new List<AcademicAchievement>();
                return this.academicAchievements;
            }

            set
            {
                this.academicAchievements = value;
            }
        }

        private IList<PersonName> names;
        public virtual IEnumerable<PersonName> Names
        {
            get
            {
                if (null == this.names)
                    this.names = new List<PersonName>();
                return this.names;
            }
            set
            {
                this.names = (IList<PersonName>)value;
            }
        }

        private IList<Photo> photos;
        public virtual IList<Photo> Photos
        {
            get
            {
                if (null == this.photos)
                    this.photos = new List<Photo>();
                return this.photos;
            }
            set
            {
                this.photos = value;
            }
        }

        #endregion

        public virtual DateTime BirthDate 
        {
            get
            {
                if (this.EffectivePeriod == null) this.EffectivePeriod = new DateTimeRange(DateTime.Now);
                return this.EffectivePeriod.From;
            }

            set
            {
                if (this.EffectivePeriod == null) this.EffectivePeriod = new DateTimeRange(value);
                else this.EffectivePeriod.From = value;
            }
        
        }
        public virtual DateTime DeceasedDate
        {
            get { return this.EffectivePeriod.To; }
            set
            {
                if (this.EffectivePeriod == null) this.EffectivePeriod = new DateTimeRange();
                this.EffectivePeriod.To = value;

            }
        }

        public virtual InterPersonRelation GetPersonRelationByCode(string code)
        {
            foreach (var e in this.personRelationships)
            {
                if (code == e.Category.Code && e.IsEffectiveNow)
                {
                    return e;
                }
            }
            return null;
        }

        public virtual InterPersonRelation GetPersonRelationByID(Int64 id)
        {
            foreach (var e in this.personRelationships)
            {
                if (id == e.Category.ID && e.IsEffectiveNow)
                {
                    return e;
                }
            }
            return null;
        }

        public virtual void AddPersonRelationOfTheSameCategory(InterPersonRelation relation)
        {
            this.PersonRelationships.Add(new iSISModel.InterPersonRelation()
            {
                Category = relation.Category,
                PrimaryPerson = relation.PrimaryPerson,
                SecondaryPerson = relation.SecondaryPerson,
                EffectivePeriod = new DateTimeRange(DateTime.Today),
            });
        }

        public virtual void AddPersonRelationAfterExpiringExistingInstancesOfTheSameCategory(InterPersonRelation relation)
        {
            ExpireExitingInstancesOfCategory(relation.Category, DateTime.Today);
            AddPersonRelationOfTheSameCategory(relation);
        }

        public virtual void ExpireExitingInstancesOfCategory(HierarchicalCategory relationCategory, DateTime expiryDate)
        {
            foreach (var e in this.PersonRelationships)
            {
                if (e.EffectivePeriod.From > expiryDate)
                    throw new Exception();
                if (e.IsEffectiveNow && e.Category == relationCategory)
                {
                    e.EffectivePeriod.Expire(expiryDate);
                }
            }
        }
        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (InterPersonRelation i in this.PersonRelationships)
            {
                i.SecondaryPerson = this;
                i.Persist(context);
            }
            foreach (AcademicEventParticipation i in this.AcademicEventParticipations)
            {
                i.Person = this;
                i.Persist(context);
            }
            foreach (AcademicAchievement i in this.AcademicAchievements)
            {
                i.Person = this;
                i.Persist(context);
            }
            foreach (Education i in this.Educations)
            {
                i.Person = this;
                i.Persist(context);
            }
            foreach (Experience i in this.Experiences)
            {
                i.Person = this;
                i.Persist(context);
            }
            foreach (PersonName n in this.Names)
            {
                n.Person = this;
                n.Persist(context);
            }
            foreach (RoyalDecoration i in this.RoyalDecorations)
            {
                i.Person = this;
                i.Persist(context);
            }
        }
    }
}
