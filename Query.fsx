#I @"D:\Projects\GuardianReviewsAzure\GuardianReviews.Web\bin"
#r @"GuardianReviews.NHibernate.dll"
#r @"NHibernate.dll"
#r @"NHibernate.Linq.dll"
#r @"FluentNHibernate.dll"
#r @"GuardianReviews.Domain.dll"
#r @"SharpArch.dll"

open GuardianReviews.NHibernate
open GuardianReviews.NHibernate.Mappings
open GuardianReviews.Domain.Model
open SharpArch.Data.NHibernate

//NHibernate setup
let pathToConfig = @"D:\Projects\GuardianReviewsAzure\GuardianReviews.Web\NHibernate.config"
let rep = new QueryRepository<GuardianReviews.Domain.Model.Review>()
let modelGenerator = new AutoPersistenceModelGenerator()
NHibernateSession.Init(new SimpleSessionStorage(), [|@"D:\Projects\GuardianReviewsAzure\GuardianReviews.Web\bin\GuardianReviews.NHibernate.dll"|], modelGenerator.Generate(), pathToConfig);
let session = NHibernateSession.GetDefaultSessionFactory().OpenSession()

//Querying
let results = rep.GetAll()
results.Count
let results2 = rep.FindAll(fun(r:Review) -> r.ReviewType.Id = 3)
results2.Count
results2 |> Seq.iter (fun r -> printfn "%s" r.Title)

//Cleanup
NHibernateSession.CloseAllSessions()
NHibernateSession.Reset()

let printReview( review : Review) = 
    printfn "%s %s" review.Title, review.PublicationDate.ToLongDateString()

    

