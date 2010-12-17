#load @"D:\Projects\GuardianReviewsAzure\Setup.fsx"
open GuardianReviews.NHibernate
open GuardianReviews.NHibernate.Mappings
open GuardianReviews.Domain.Model
open SharpArch.Data.NHibernate

//Querying

let rep = new QueryRepository<Review>()
let results2 = rep.FindAll(fun(r:Review) -> r.ReviewType = ReviewTypes.Music)
results2.Count
results2 |> Seq.iter (fun r -> printfn "%s %s" r.Title r.ReviewType.DisplayName)
let rev = results2.Item(0)
rev.Title
let results3 = rep.FindAll(fun(r:Review) -> r = rev)
//Cleanup
NHibernateSession.CloseAllSessions()
NHibernateSession.Reset()

let printReview( review : Review) = 
    printfn "%s %s" review.Title, review.PublicationDate.ToLongDateString()

    

