#I @"D:\Projects\GuardianReviewsAzure\GuardianReviews.Web\bin"
#r @"GuardianReviews.NHibernate.dll"
#r @"NHibernate.dll"
#r @"NHibernate.Linq.dll"
#r @"FluentNHibernate.dll"
#r @"GuardianReviews.Domain.dll"
#r @"SharpArch.dll"
#r @"Newtonsoft.json.dll"

open GuardianReviews.NHibernate
open GuardianReviews.NHibernate.Mappings
open GuardianReviews.Domain.Model
open SharpArch.Data.NHibernate


//NHibernate setup
let pathToConfig = @"D:\Projects\GuardianReviewsAzure\GuardianReviews.Web\NHibernate.config"
let modelGenerator = new AutoPersistenceModelGenerator()
NHibernateSession.Init(new SimpleSessionStorage(), [|@"D:\Projects\GuardianReviewsAzure\GuardianReviews.Web\bin\GuardianReviews.NHibernate.dll"|], modelGenerator.Generate(), pathToConfig);
let session = NHibernateSession.GetDefaultSessionFactory().OpenSession()
